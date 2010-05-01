using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Windows.Input;
using DietRecorder.Client.ViewModel;
using DietRecorder.Client.Common;
using DietRecorder.DataAccess;
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
            userVM.PropertyChanged += handler.HandlepropertyChanged;

            // act
            userVM.Name = "test";

            // assert
            Assert.AreEqual("Name", handler.PropertyName);
        }

        [Test]
        public void CancelNewUserCommand_Called_MakesNewUserButtonVisible()
        {
            // arrange
            UserViewModel userVM = CreateUserViewModel();
            userVM.Mode = ViewMode.Edit; // ensures button isn't visible
            ICommand command = userVM.CancelNewUserCommand;

            // act
            command.Execute(null);

            // assert
            Assert.IsTrue(userVM.NewUserButtonsVisible);
        }

        private static UserViewModel CreateUserViewModel()
        {
            IRepository repository = MockRepository.GenerateStub<IRepository>();
            return new UserViewModel(repository, null);
        }
    }

    internal class PropertyChangedTestHandler
    {
        internal string PropertyName = string.Empty;

        internal void HandlepropertyChanged(object sender, PropertyChangedEventArgs eventArgs)
        {
            PropertyName = eventArgs.PropertyName;
        }
    }
}
