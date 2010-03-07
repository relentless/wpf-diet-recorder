using System;
using System.Collections.Generic;
using DietRecorder.Model;

namespace DietRecorder.DataAccess
{
    public interface IRepository
    {
        UserList Load();
        void Delete(Measurement measurement);
        void Save(UserList userList);
    }
}
