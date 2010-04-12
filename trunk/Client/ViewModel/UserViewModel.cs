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
        private DelegateCommand newUserCommand;
        private DelegateCommand cancelNewUserCommand;

        private CustomMeasurementDefinitionViewModel definitionViewModel;

        public UserViewModel()
        {
            SetupCommands();
            definitionViewModel = new CustomMeasurementDefinitionViewModel();
            definitionViewModel.MeasurementDefinitions = new ObservableCollection<CustomMeasurementDefinition>();
            Mode = ViewMode.View;
        }

        private void SetupCommands()
        {
            addUserCommand = new DelegateCommand(AddUser);
            deleteUserCommand = new DelegateCommand(DeleteUser);
            newUserCommand = new DelegateCommand(NewUser);
            cancelNewUserCommand = new DelegateCommand(CancelNewUser);
        }

        public ObservableCollection<User> Users { get; set; }

        public User SelectedUser { private get; set; }

        public ICommand AddUserCommand
        {
            get { return addUserCommand; }
        }

        public ICommand DeleteUserCommand
        {
            get { return deleteUserCommand; }
        }

        public ICommand NewUserCommand
        {
            get { return newUserCommand; }
        }

        public ICommand CancelNewUserCommand
        {
            get { return cancelNewUserCommand; }
        }

        private void AddUser()
        {
            User newUser = new User();
            newUser.UserName = name;
            Users.Add(newUser);
            Name = string.Empty;

            Mode = ViewMode.View;
        }

        private void DeleteUser()
        {
            if (SelectedUser != null)
            {
                Users.Remove(SelectedUser);
            }
        }

        private void NewUser()
        {
            Mode = ViewMode.Edit;
        }

        private void CancelNewUser()
        {
            Mode = ViewMode.View;
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

        private ViewMode viewMode;
        public ViewMode Mode
        {
            set
            {
                if (value != viewMode)
                {
                    viewMode = value;
                    NotifyPropertyChanged("NewUserButtonsVisible");
                    NotifyPropertyChanged("AddUserButtonsVisible");
                    NotifyPropertyChanged("NameBoxEditable");
                }
            }
        }

        public bool NewUserButtonsVisible 
        {
            get
            {
                return viewMode == ViewMode.View;
            }
        }

        public bool AddUserButtonsVisible
        {
            get
            {
                return viewMode == ViewMode.Edit;
            }
        }

        public bool NameBoxEditable
        {
            get
            {
                return viewMode == ViewMode.Edit;
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
