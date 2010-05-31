using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Windows.Input;
using System.Linq;
using DietRecorder.Client.ViewModel;
using DietRecorder.Client.Common;
using DietRecorder.Model;
using DietRecorder.DataAccess;
using NUnit.Framework;
using Rhino.Mocks;

namespace DietRecorder_Tests.Client.ViewModel
{
    [TestFixture]
    public class MeasurementViewModel_Tests
    {
        [Test]
        public void Constructor_Called_SetsUserList()
        {
            // arrange
            User userInDatabase = new User();
            IRepository repository = CreateRepositoryWithUsers(userInDatabase);
            
            // act
            MeasurementViewModel measurementVM = new MeasurementViewModel(repository, new MessageDisplay());

            // assert
            Assert.IsNotNull(measurementVM.Users);
            Assert.AreEqual(userInDatabase, measurementVM.Users[0]);
        }

        [Test]
        public void Constructor_Called_SetsSelectedUserToFirstUserInList()
        {
            // arrange
            User userInDatabase1 = new User();
            IRepository repository = CreateRepositoryWithUsers(userInDatabase1, new User());

            // act
            MeasurementViewModel measurementVM = new MeasurementViewModel(repository, new MessageDisplay());

            // assert
            Assert.IsNotNull(measurementVM.Users);
            Assert.AreEqual(userInDatabase1, measurementVM.SelectedUser);
        }

        [Test]
        public void Constructor_Called_SetsViewModeTrue()
        {
            // arrange

            // act
            MeasurementViewModel measurementVM = CreateMeasurementViewModelWithUser();

            // assert
            Assert.IsTrue(measurementVM.ViewMode);
        }

        [Test]
        public void SelectedUser_Set_SetsMeasurementList()
        {
            // arrange
            Measurement measurement1 = new Measurement();
            Measurement measurement2 = new Measurement();
            User user = CreateUserWithMeasurements(measurement1, measurement2);

            MeasurementViewModel measurementVM = new MeasurementViewModel(MockRepository.GenerateStub<IRepository>());

            // act
            measurementVM.SelectedUser = user;

            // assert
            Assert.Contains(measurement1, measurementVM.Measurements);
            Assert.Contains(measurement2, measurementVM.Measurements);
        }

        [Test]
        public void SelectedUser_Set_SelectsFirstMeasurementInList()
        {
            // arrange
            Measurement measurement1 = new Measurement();
            User user = CreateUserWithMeasurements(measurement1, new Measurement());
            MeasurementViewModel measurementVM = new MeasurementViewModel(MockRepository.GenerateStub<IRepository>());

            // act
            measurementVM.SelectedUser = user;

            // assert
            Assert.AreEqual(measurement1, measurementVM.SelectedMeasurement);
        }

        //[Test]
        //public void SelectedMeasurement_Set_SetsMeasurementDate()
        //{
        //    // arrange
        //    DateTime measurementDate = new DateTime(2000, 1, 1);
        //    MeasurementViewModel measurementVM = new MeasurementViewModel(MockRepository.GenerateStub<IRepository>());

        //    // act
        //    measurementVM.SelectedMeasurement = new Measurement(measurementDate, 0, string.Empty);

        //    // assert
        //    Assert.AreEqual(measurementDate, measurementVM.MeasurementDate);
        //}

        //[Test]
        //public void SelectedMeasurement_Set_SetsMeasurementWeight()
        //{
        //    // arrange
        //    double measurementWeight = 9.9;
        //    MeasurementViewModel measurementVM = new MeasurementViewModel(MockRepository.GenerateStub<IRepository>());

        //    // act
        //    measurementVM.SelectedMeasurement = new Measurement(new DateTime(), measurementWeight, string.Empty);

        //    // assert
        //    Assert.AreEqual(measurementWeight, measurementVM.WeightKg);
        //}

        //[Test]
        //public void SelectedMeasurement_Set_SetsMeasurementNotes()
        //{
        //    // arrange
        //    string measurementNotes = "test";
        //    MeasurementViewModel measurementVM = new MeasurementViewModel(MockRepository.GenerateStub<IRepository>());

        //    // act
        //    measurementVM.SelectedMeasurement = new Measurement(new DateTime(), 0, measurementNotes);

        //    // assert
        //    Assert.AreEqual(measurementNotes, measurementVM.Notes);
        //}

        [Test]
        public void NewMeasurementCommand_Called_SetsSelectedMeasurementToNewMeasurement()
        {
            // arrange
            MeasurementViewModel measurementVM = CreateMeasurementViewModelWithUser();
            measurementVM.SelectedMeasurement = new Measurement(new DateTime(), 999, string.Empty);

            // act
            measurementVM.NewMeasurementCommand.Execute(null);

            // assert
            Assert.AreEqual(0, measurementVM.SelectedMeasurement.WeightKg);
        }

        [Test]
        public void NewMeasurementCommand_Called_SetsViewModeFalse()
        {
            // arrange
            MeasurementViewModel measurementVM = CreateMeasurementViewModelWithUser();
            measurementVM.ViewMode = true;

            // act
            measurementVM.NewMeasurementCommand.Execute(null);

            // assert
            Assert.IsFalse(measurementVM.ViewMode);
        }

        [Test]
        public void AddMeasurementCommand_Called_AddsNewMeasurementToMeasurementList()
        {
            // arrange
            MeasurementViewModel measurementVM = CreateMeasurementViewModelWithUser();
            measurementVM.MeasurementDate = "19/03/2011";
            measurementVM.WeightKg = "123.65";
            measurementVM.Notes = "test";

            // act
            measurementVM.AddMeasurementCommand.Execute(null);

            // assert
            Assert.AreEqual(1, measurementVM.Measurements.Count);
            Assert.AreEqual("19/03/2011", measurementVM.Measurements[0].Date.ToShortDateString());
            Assert.AreEqual(123.65, measurementVM.Measurements[0].WeightKg);
            Assert.AreEqual("test", measurementVM.Measurements[0].Notes);
        }

        [Test]
        public void AddMeasurementCommand_Called_SavesNewMeasurementToRepository()
        {
            // arrange
            IRepository repository = CreateRepositoryWithUsers(new User());
            MeasurementViewModel measurementVM = new MeasurementViewModel(repository);
            measurementVM.MeasurementDate = "19/03/2011";
            measurementVM.WeightKg = "123.65";
            measurementVM.Notes = "test";

            // act
            measurementVM.AddMeasurementCommand.Execute(null);

            // assert
            List<object[]> parameterList = (List<object[]>)repository.GetArgumentsForCallsMadeOn(x => x.SaveUserList(null));
            List<User> savedUserList = (List<User>)parameterList[0][0];
            Assert.AreEqual("19/03/2011", savedUserList[0].Measurements[0].Date.ToShortDateString());
            Assert.AreEqual(123.65, savedUserList[0].Measurements[0].WeightKg);
            Assert.AreEqual("test", savedUserList[0].Measurements[0].Notes);
        }

        [Test]
        public void AddMeasurementCommand_Called_SetsViewModeTrue()
        {
            // arrange
            MeasurementViewModel measurementVM = CreateMeasurementViewModelWithUser();
            measurementVM.ViewMode = false;
            SetValidMeasurementFields(measurementVM);

            // act
            measurementVM.AddMeasurementCommand.Execute(null);

            // assert
            Assert.IsTrue(measurementVM.ViewMode);
        }

        [Test]
        public void AddMeasurementCommand_Called_NotifiesMeasurementsChanged()
        {
            // arrange
            MeasurementViewModel measurementVM = CreateMeasurementViewModelWithUser();

            PropertyChangedTestHandler handler = new PropertyChangedTestHandler();
            measurementVM.PropertyChanged += handler.HandlePropertyChanged;
            SetValidMeasurementFields(measurementVM);

            // act
            measurementVM.AddMeasurementCommand.Execute(null);

            // assert
            Assert.AreEqual("Measurements", handler.PropertyName);
        }

        [Test]
        [Ignore("TODO: Use factory for model so we can test this")]
        public void AddMeasurementCommand_Called_ChecksMeasurementForValidationErrors()
        {
            // arrange
            Measurement measurement = MockRepository.GenerateMock<Measurement>();
            measurement.Expect(x => x.GetValidationFailures()).Return(new List<string>());
            MeasurementViewModel measurementVM = CreateMeasurementViewModelWithUser();
            measurementVM.SelectedMeasurement = measurement;

            // act
            measurementVM.AddMeasurementCommand.Execute(null);

            // assert
            measurement.AssertWasCalled(x => x.GetValidationFailures());
        }

        [Test]
        [Ignore("TODO: Use factory for model so we can test this")]
        public void AddMeasurementCommand_CalledWithInvalidMeasurement_DisplaysSingleValidationMessageCorrectly()
        {
            // arrange
            Measurement measurement = MockRepository.GenerateMock<Measurement>();
            measurement.Expect(x => x.GetValidationFailures()).Return(new List<string>() {"failure"}).Repeat.Any();
            IRepository repository = MockRepository.GenerateStub<IRepository>();
            IMessageDisplay messageBox = MockRepository.GenerateStub<IMessageDisplay>();
            MeasurementViewModel measurementVM = new MeasurementViewModel(repository, messageBox);
            measurementVM.SelectedMeasurement = measurement;

            // act
            measurementVM.AddMeasurementCommand.Execute(null);

            // assert
            messageBox.AssertWasCalled(x => x.ShowMessage("Validation Failure", "failure"));
        }

        [Test]
        [Ignore("TODO: Use factory for model so we can test this")]
        public void AddMeasurementCommand_CalledWithInvalidMeasurement_DisplaysMultipleValidationMessageCorrectly()
        {
            // arrange
            Measurement measurement = MockRepository.GenerateMock<Measurement>();
            measurement.Expect(x => x.GetValidationFailures()).Return(new List<string>() { "failure1", "failure2" }).Repeat.Any();
            IRepository repository = MockRepository.GenerateStub<IRepository>();
            IMessageDisplay messageBox = MockRepository.GenerateStub<IMessageDisplay>();
            MeasurementViewModel measurementVM = new MeasurementViewModel(repository, messageBox);
            measurementVM.SelectedMeasurement = measurement;

            // act
            measurementVM.AddMeasurementCommand.Execute(null);

            // assert
            messageBox.AssertWasCalled(x => x.ShowMessage("Validation Failure", "failure1" + Environment.NewLine + "failure2"));
        }

        [Test]
        public void MeasurementDate_SetWithInvalidDate_TurnsWarningOn()
        {
            // arrange
            MeasurementViewModel measurementVM = new MeasurementViewModel(MockRepository.GenerateStub<IRepository>(), null);
            
            // act
            measurementVM.MeasurementDate = "invaliddate";

            // assert
            Assert.IsFalse(measurementVM.MeasurementDateIsCorrectFormat);
        }

        [Test]
        public void MeasurementDate_SetWithValidDate_TurnsWarningOff()
        {
            // arrange
            MeasurementViewModel measurementVM = new MeasurementViewModel(MockRepository.GenerateStub<IRepository>(), null);

            // act
            measurementVM.MeasurementDate = "1/1/2010";

            // assert
            Assert.IsTrue(measurementVM.MeasurementDateIsCorrectFormat);
        }

        [Test]
        public void WeightKg_SetWithInvalidWeight_TurnsWarningOn() {
            // arrange
            MeasurementViewModel measurementVM = new MeasurementViewModel(MockRepository.GenerateStub<IRepository>(), null);

            // act
            measurementVM.WeightKg = "invalidweight";

            // assert
            Assert.IsFalse(measurementVM.WeightKgIsCorrectFormat);
        }

        [Test]
        public void WeightKg_SetWithValidWeight_TurnsWarningOff() {
            // arrange
            MeasurementViewModel measurementVM = new MeasurementViewModel(MockRepository.GenerateStub<IRepository>(), null);

            // act
            measurementVM.WeightKg = "123.456";

            // assert
            Assert.IsTrue(measurementVM.WeightKgIsCorrectFormat);
        }

        [Test]
        public void RemoveMeasurementCommand_Called_RemovesSelectedMeasurementFromMeasurementList()
        {
            // arrange
            Measurement measurement = new Measurement();
            User user = CreateUserWithMeasurements(measurement);

            MeasurementViewModel measurementVM = new MeasurementViewModel(CreateRepositoryWithUsers(user));
            measurementVM.SelectedMeasurement = measurement;

            // act
            measurementVM.RemoveMeasurementCommand.Execute(null);

            // assert
            Assert.AreEqual(0, measurementVM.Measurements.Count);
        }

        [Test]
        public void RemoveMeasurementCommand_Called_DeletesSelectedMeasurementInRepository()
        {
            // arrange
            Measurement measurement = new Measurement();

            IRepository repository = CreateRepositoryWithUsers(new User());
            MeasurementViewModel measurementVM = new MeasurementViewModel(repository);
            measurementVM.SelectedMeasurement = measurement;

            // act
            measurementVM.RemoveMeasurementCommand.Execute(null);

            // assert
            List<object[]> parameterList = (List<object[]>)repository.GetArgumentsForCallsMadeOn(x => x.Delete(null));
            object deletedObject = parameterList[0][0];
            Assert.AreEqual(measurement, deletedObject);
        }

        [Test]
        public void RemoveMeasurementCommand_Called_SelectsFirstMeasurementInList()
        {
            // arrange
            Measurement measurement1 = new Measurement();
            Measurement measurement2 = new Measurement();
            User user = CreateUserWithMeasurements(measurement1, measurement2);

            MeasurementViewModel measurementVM = new MeasurementViewModel(CreateRepositoryWithUsers(user));
            measurementVM.SelectedMeasurement = measurement1;

            // act
            measurementVM.RemoveMeasurementCommand.Execute(null);

            // assert
            Assert.AreEqual(measurement2, measurementVM.SelectedMeasurement);
        }

        [Test]
        public void CancelNewMeasurementCommand_Called_SelectsFirstMeasurementInList()
        {
            // arrange
            Measurement measurement1 = new Measurement();
            User user = CreateUserWithMeasurements(measurement1);

            MeasurementViewModel measurementVM = new MeasurementViewModel(CreateRepositoryWithUsers(user));
            measurementVM.SelectedMeasurement = null;

            // act
            measurementVM.CancelNewMeasurementCommand.Execute(null);

            // assert
            Assert.AreEqual(measurement1, measurementVM.SelectedMeasurement);
        }

        [Test]
        public void CancelNewMeasurementCommand_Called_SetsSelecedMeasurementToNull()
        {
            // arrange
            MeasurementViewModel measurementVM = new MeasurementViewModel(CreateRepositoryWithUsers(new User()));
            measurementVM.SelectedMeasurement = new Measurement();

            // act
            measurementVM.CancelNewMeasurementCommand.Execute(null);

            // assert
            Assert.IsNull(measurementVM.SelectedMeasurement);
        }

        [Test]
        public void CancelNewMeasurementCommand_Called_SetsViewModeTrue()
        {
            // arrange
            MeasurementViewModel measurementVM = CreateMeasurementViewModelWithUser();
            measurementVM.ViewMode = false;

            // act
            measurementVM.CancelNewMeasurementCommand.Execute(null);

            // assert
            Assert.IsTrue(measurementVM.ViewMode);
        }

        private static void SetValidMeasurementFields(MeasurementViewModel measurementVM) {
            measurementVM.MeasurementDate = "03/09/2001";
            measurementVM.WeightKg = "333.45";
            measurementVM.Notes = "hello mum";
        }

        private static MeasurementViewModel CreateMeasurementViewModelWithUser()
        {
            IRepository repository = CreateRepositoryWithUsers(new User());
            return new MeasurementViewModel(repository);
        }

        private static IRepository CreateRepositoryWithUsers(params User[] usersInDatabase)
        {
            IRepository repository = MockRepository.GenerateStub<IRepository>();
            repository.Expect(x => x.LoadUserList()).Return(usersInDatabase.ToList<User>());
            return repository;
        }

        private static User CreateUserWithMeasurements(params Measurement[] measurements)
        {
            User user = new User();
            user.Measurements = measurements.ToList<Measurement>();
            return user;
        }
    }
}
