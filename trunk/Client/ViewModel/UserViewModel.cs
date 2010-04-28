﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using DietRecorder.Model;
using DietRecorder.Client.Common;
using DietRecorder.DataAccess;
using System.Windows.Input;
using System.Linq;

namespace DietRecorder.Client.ViewModel
{
    class UserViewModel: INotifyPropertyChanged
    {
        private readonly IRepository repository;
        private CustomMeasurementDefinitionViewModel definitionViewModel;
        private User selectedUser;
        private string name;
        private ViewMode viewMode;
        public ObservableCollection<User> Users { get; set; }
        public int someVal { get; set; }

        public event Action UsersUpdated;
        public event Action<User> UserDeleted;

        #region Commands
        private DelegateCommand addUserCommand;
        private DelegateCommand deleteUserCommand;
        private DelegateCommand newUserCommand;
        private DelegateCommand cancelNewUserCommand;

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
        #endregion Commands

        #region Notify Property Stuff
        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(string PropertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(PropertyName));
            }
        }
        #endregion Notify Property Stuff

        #region Properties with NotifyProperty
        public CustomMeasurementDefinitionViewModel DefinitionViewModel 
        {
            get
            {
                return definitionViewModel;
            }
            set
            {
                definitionViewModel = value;
                NotifyPropertyChanged("DefinitionViewModel");
            }
        }

        public User SelectedUser
        {
            get
            {
                return selectedUser;
            }

            set
            {
                selectedUser = value;
                if (selectedUser != null)
                {
                    DefinitionViewModel.MeasurementDefinitions = selectedUser.Definitions.ToObservableCollection<CustomMeasurementDefinition>();
                    definitionViewModel.IsEnabled = true;
                }
                else
                {
                    definitionViewModel.ResetContents();
                    definitionViewModel.IsEnabled = false;
                }
                NotifyPropertyChanged("SelectedUser");
            }
        }
        
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
                    name = value;
                    NotifyPropertyChanged("Name");
                }
            }
        }
        
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
        #endregion Properties with NotifyProperty

        public UserViewModel(CustomMeasurementDefinitionViewModel customMeasurementDefinitionViewModel)
        {
            SetupCommands();
            //DefinitionViewModel = customMeasurementDefinitionViewModel;
            Mode = ViewMode.View;

            someVal = 15;
        }

        private void SetupCommands()
        {
            addUserCommand = new DelegateCommand(AddUser);
            deleteUserCommand = new DelegateCommand(DeleteUser);
            newUserCommand = new DelegateCommand(NewUser);
            cancelNewUserCommand = new DelegateCommand(CancelNewUser);
        }

        private void AddUser()
        {
            User newUser = new User();
            newUser.UserName = name;

            IList<CustomMeasurementDefinition> definitionList = new List<CustomMeasurementDefinition>();
            foreach( CustomMeasurementDefinition definition in DefinitionViewModel.MeasurementDefinitions)
            {
                definitionList.Add(definition);
            }
            
            newUser.Definitions = definitionList;
            Users.Add(newUser);
            Name = string.Empty;

            Mode = ViewMode.View;
            definitionViewModel.ResetContents();
            SelectedUser = newUser;
            NotifyUsersUpdated();
        }

        private void DeleteUser()
        {
            if (SelectedUser != null)
            {
                NotifyUserDeleted(selectedUser);
                Users.Remove(selectedUser);
                SelectFirstUser();
            }
        }

        private void NewUser()
        {
            Mode = ViewMode.Edit;
            SelectedUser = null;
            definitionViewModel.ResetContents();
            definitionViewModel.IsEnabled = true;
        }

        private void CancelNewUser()
        {
            Mode = ViewMode.View;
            SelectFirstUser();
        }

        private void SelectFirstUser()
        {
            if (Users.Count > 0)
            {
                SelectedUser = Users.First();
            }
        }

        private void NotifyUsersUpdated()
        {
            if (UsersUpdated != null)
            {
                UsersUpdated.Invoke();
            }
        }

        private void NotifyUserDeleted(User DeletedUser)
        {
            if (UserDeleted != null)
            {
                UserDeleted.Invoke(DeletedUser);
            }
        }
    }
}