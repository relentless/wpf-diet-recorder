using System;
using System.Collections.Generic;
using DietRecorder.Model;

namespace DietRecorder.DataAccess
{
    public interface IRepository
    {
        IList<User> LoadUserList();
        void SaveUserList(IEnumerable<User> Users);
        void Delete(object obj);
    }
}
