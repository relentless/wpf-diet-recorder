using System;
using System.Collections.Generic;
using DietRecorder.Model;

namespace DietRecorder.BusinessLayer
{
    public interface IDietLogic
    {
        void SaveUserList(IEnumerable<User> Users);
        IList<User> LoadUserList();
        void Delete(object obj);
    }
}
