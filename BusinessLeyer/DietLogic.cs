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

        public void DeleteMeasurement(Measurement measurement)
        {
            repository.Delete(measurement);
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
    }
}
