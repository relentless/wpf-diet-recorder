using System;
using System.Collections.Generic;
using DietRecorder.Model;
using DietRecorder.DataAccess;

namespace DietRecorder.BusinessLayer
{
    public class DietLogic: IDietLogic
    {
        private IRepository repository;

        public DietLogic(IRepository repository)
        {
            this.repository = repository;
        }

        public IList<User> LoadUserList()
        {
            IList<User> users = (IList<User>)repository.Load();

            if (users != null)
                return users;
            else
                return new List<User>();
        }

        public void SaveUserList(IEnumerable<User> Users)
        {
            repository.Save(Users);
        }

        public void Delete(object obj)
        {
            repository.Delete(obj);
        }
    }
}
