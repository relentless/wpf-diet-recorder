using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using DietRecorder.Model;
using DietRecorder.Client.Common;
using System.Windows.Input;

namespace DietRecorder.Client.ViewModel
{
    class UserViewModel: INotifyPropertyChanged
    {
        private DelegateCommand addUserCommand;
        private DelegateCommand deleteUserCommand;

        public UserViewModel()
        {
            addUserCommand = new DelegateCommand(AddUser);
            deleteUserCommand = new DelegateCommand(DeleteUser);
        }

        public ICommand AddUserCommand
        {
            get { return addUserCommand; }
        }

        public ICommand DeleteUserCommand
        {
            get { return deleteUserCommand; }
        }

        private void AddUser()
        {

        }

        private void DeleteUser()
        {

        }

        private string name;
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                if (value != name)
                {
                    name= value;
                    NotifyPropertyChanged("Name");
                }
            }
        }

        private ObservableCollection<User> users;
        public ObservableCollection<User> Users
        {
            get
            {
                return users;
            }
            set
            {
                if (value != users)
                {
                    users= value;
                    NotifyPropertyChanged("Users");
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(string PropertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(PropertyName));
            }
        }
    }
}
