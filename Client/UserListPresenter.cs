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

        public UserListPresenter(UserListView view, IDietLogic dietLogic, UserList userList)
        {
            this.view = view;
            view.Presenter = this;
            this.dietLogic = dietLogic;
            this.userList = userList;
        }

        public void DisplayView()
        {
            view.SetListBinding(userList);
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
                dietLogic.DeleteUser((User)view.UserList.SelectedItem);
                userList.Remove((User)view.UserList.SelectedItem);
            }
        }
    }
}
