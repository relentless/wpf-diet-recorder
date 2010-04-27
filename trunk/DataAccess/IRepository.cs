using System;
using System.Collections.Generic;
using DietRecorder.Model;
using User = DietRecorder.Model.User;

namespace DietRecorder.DataAccess
{
    public interface IRepository
    {
        IEnumerable<User> Load();
        void Save(IEnumerable<User> Users);
        void Delete(object obj);
    }
}
