using DietRecorder.Client.ViewModel;
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
            UserViewModel userVM = new UserViewModel(MockRepository.GenerateStub<IRepository>(), null);

            PropertyChangedTestHandler handler = new PropertyChangedTestHandler();
            userVM.PropertyChanged += handler.HandlePropertyChanged;

            // act
            userVM.Name = "test";

            // assert
            Assert.AreEqual("Name", handler.PropertyName);
        }
    }
}
