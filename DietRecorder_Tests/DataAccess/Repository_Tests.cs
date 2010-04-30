using System;
using System.Collections.Generic;
using NUnit.Framework;
using Rhino.Mocks;
using DietRecorder.DataAccess;
using Db4objects.Db4o;
using User = DietRecorder.Model.User;

namespace DietRecorder_Tests.DataAccess
{
    [TestFixture]
    public class Repository_Tests
    {
        [Test]
        public void LoadUserList_NoUsersInDatabase_ReturnsEmptyList()
        {
            // arrange
            IObjectContainer database = MockRepository.GenerateStub<IObjectContainer>();
            Repository repository = new Repository(database);

            // act
            IList<User> result = repository.LoadUserList();

            // assert
            Assert.IsNotNull(result, "Should return empty list not null");
        }

        [Test]
        public void LoadUserList_UsersInDatabase_ReturnsUsers()
        {
            // arrange
            IList<User> usersInDatabase = new List<User>() {
                new User(), new User()
            };

            IObjectContainer database = MockRepository.GenerateStub<IObjectContainer>();
            database.Expect(x => x.Query<User>()).Return(usersInDatabase);
            Repository repository = new Repository(database);

            // act
            IList<User> result = repository.LoadUserList();

            // assert
            Assert.AreEqual(usersInDatabase, result, "List from database was not returned");
        }
    }
}
