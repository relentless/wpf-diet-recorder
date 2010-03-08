using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DietRecorder.BusinessLeyer;
using DietRecorder.Model;

namespace DietRecorder.Client
{
    public class UserListPresenter
    {
        private UserListView view;
        private IDietLogic dietLogic;
        private UserList userList;
        private User selectedUser;

        public UserListPresenter(UserListView view, IDietLogic dietLogic, UserList userList)
        {
            this.view = view;
            view.Presenter = this;
            this.dietLogic = dietLogic;
            this.userList = userList;
        }

        public void DisplayView()
        {
            view.SetUserListBinding(userList);
            view.ShowDialog();
        }

        public void AddUser()
        {
            string userName = view.UserName;
            userList.Add(new User(userName));
            dietLogic.SaveUserList(userList);
            view.UserName = string.Empty;
        }

        public void DeleteUser()
        {
            if (view.UserList.SelectedItem != null)
            {
                dietLogic.Delete(view.UserList.SelectedItem);
                userList.Remove((User)view.UserList.SelectedItem);
            }
        }

        public void DisplayUser()
        {
            if (view.UserList.SelectedItem != null)
            {
                selectedUser = (User)view.UserList.SelectedItem;
                view.SetCustomMeasurementListBinding(selectedUser.Definitions);
            }
            else
            {
                view.SetCustomMeasurementListBinding(null);
            }
        }

        public void AddMeasurementDefinition()
        {
            if (selectedUser != null)
            {
                string measurementName = view.MeasurementName;
                selectedUser.Definitions.Add(new CustomMeasurementDefinition(measurementName));
                dietLogic.SaveUserList(userList);
                view.MeasurementName = string.Empty;
            }
            else
            {
                view.ShowMessage("Problem", "Please select a user");
            }
        }

        public void DeleteMeasurementDefinition()
        {
            if (view.CustomMeasurementList.SelectedItem != null)
            {
                if (selectedUser != null)
                {
                    dietLogic.Delete(view.CustomMeasurementList.SelectedItem);
                    selectedUser.Definitions.Remove((CustomMeasurementDefinition)view.CustomMeasurementList.SelectedItem);
                }
            }
        }
    }
}
