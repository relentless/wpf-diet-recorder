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

        public UserListPresenter(UserListView view, IDietLogic dietLogic)
        {
            this.view = view;
            view.Presenter = this;
            this.dietLogic = dietLogic;
        }

        public void DisplayView()
        {
            userList = dietLogic.LoadUserList();
            view.SetListBinding(userList);
            view.ShowDialog();
        }

        public void AddUser()
        {
            string userName = view.UserName;
            userList.Add(new User(userName));
            view.UserName = string.Empty;
        }
    }
}
