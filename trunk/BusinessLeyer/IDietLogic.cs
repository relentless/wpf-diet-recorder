using System;
using System.Collections.Generic;
using DietRecorder.Model;

namespace DietRecorder.BusinessLeyer
{
    public interface IDietLogic
    {
        void SaveUserList(UserList userList);
        void DeleteMeasurement(Measurement measurement);
        UserList LoadUserList();
    }
}
