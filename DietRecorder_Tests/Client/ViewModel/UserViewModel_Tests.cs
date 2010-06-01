using System.Collections.Generic;
using DietRecorder.Client.ViewModel;
using DietRecorder.DataAccess;
using DietRecorder.Client.Common;
using DietRecorder.Model;
using NUnit.Framework;
using Rhino.Mocks;

namespace DietRecorder_Tests.Client.ViewModel
{
    [TestFixture]
    public class UserViewModel_Tests
    {
        [Test]
        public void Name_Set_NotifiesChanged()
        {
            // arrange
            UserViewModel userVM = CreateUserViewModel();

            PropertyChangedTestHandler handler = new PropertyChangedTestHandler();
            userVM.PropertyChanged += handler.HandlePropertyChanged;

            // act
            userVM.Name = "test";

            // assert
            Assert.AreEqual("Name", handler.PropertyName);
        }

        [Test]
        public void Constructor_MultipleUsers_SelectsFirstUserInList()
        {
            // arrange
            User firstUser = new User("Bill", null, null);

            List<User> users = new List<User>() {
                firstUser,
                new User("Ted", null, null)
            };

            IRepository repository = MockRepository.GenerateStub<IRepository>();
            repository.Expect(x => x.LoadUserList()).Return(users);

            // act
            UserViewModel userVM = CreateUserViewModel(repository);

            // assert
            Assert.AreEqual(firstUser, userVM.SelectedUser);
        }

        [Test]
        public void ModifyUserCommand_Called_SetsModeToEdit()
        {
            // arrange
            UserViewModel userVM = CreateUserViewModel();
            userVM.Mode = ViewMode.View;

            // act
            userVM.ModifyUserCommand.Execute(null);

            // assert
            Assert.AreEqual(ViewMode.Edit, userVM.Mode);
        }

        [Test]
        public void ModifyUserCommand_Called_EnablesDefinitionViewModel()
        {
            // arrange
            CustomMeasurementDefinitionViewModel definitionVM = MockRepository.GenerateMock<CustomMeasurementDefinitionViewModel>();
            UserViewModel userVM = CreateUserViewModel(definitionVM);
            definitionVM.IsEnabled = false;

            // act
            userVM.ModifyUserCommand.Execute(null);

            // assert
            Assert.IsTrue(definitionVM.IsEnabled);
        }

        [Test]
        public void SelectedUser_Set_SetsNameField()
        {
            // arrange
            User user = new User("Joe", null, null);
            UserViewModel userVM = CreateUserViewModel();

            // act
            userVM.SelectedUser = user;

            // assert
            Assert.AreEqual("Joe", userVM.Name);
        }

        private static UserViewModel CreateUserViewModel()
        {
            return CreateUserViewModel(MockRepository.GenerateStub<IRepository>());
        }

        private static UserViewModel CreateUserViewModel(CustomMeasurementDefinitionViewModel definitionViewModel)
        {
            return CreateUserViewModel(MockRepository.GenerateStub<IRepository>(), definitionViewModel);
        }

        private static UserViewModel CreateUserViewModel(IRepository repository)
        {
            return CreateUserViewModel(repository, MockRepository.GenerateStub<CustomMeasurementDefinitionViewModel>());
        }

        private static UserViewModel CreateUserViewModel(IRepository repository, CustomMeasurementDefinitionViewModel definitionViewModel)
        {
            return new UserViewModel(repository, definitionViewModel);
        }
    }
}
