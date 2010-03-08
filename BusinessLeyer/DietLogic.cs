using System;
using System.Collections.Generic;
using DietRecorder.Model;
using DietRecorder.DataAccess;

namespace DietRecorder.BusinessLeyer
{
    public class DietLogic: IDietLogic
    {
        private IRepository repository;

        public DietLogic(IRepository repository)
        {
            this.repository = repository;
        }

        public UserList LoadUserList()
        {
            UserList userList = repository.Load();

            if (userList != null)
                return userList;
            else
                return new UserList();
        }

        public void SaveUserList(UserList userList)
        {
            repository.Save(userList);
        }

        public void DeleteUser(User user)
        {
            repository.Delete(user);
        }
    }
}
