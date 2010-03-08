using System;
using System.Collections.Generic;
using DietRecorder.Model;

namespace DietRecorder.DataAccess
{
    public interface IRepository
    {
        UserList Load();
        void Save(UserList userList);
        void Delete(object obj);
    }
}
