using System;
using System.Collections.Generic;
using DietRecorder.Model;

namespace DietRecorder.BusinessLeyer
{
    public interface IDietLogic
    {
        void SaveUserList(UserList userList);
        UserList LoadUserList();
        void Delete(object obj);
    }
}
