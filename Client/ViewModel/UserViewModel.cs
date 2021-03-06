﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using DietRecorder.Model;
using DietRecorder.Client.Common;
using DietRecorder.DataAccess;
using System.Windows.Input;
using System.Linq;

namespace DietRecorder.Client.ViewModel
{
    public class UserViewModel : ViewModelBase
    {
        private readonly IRepository _repository;
        private CustomMeasurementDefinitionViewModel _definitionViewModel;
        private User _selectedUser;
        private string _name;
        private ViewMode _viewMode;
        public ObservableCollection<User> Users { get; set; }

        public event Action UsersChanged;

        public UserViewModel(IRepository Repository, CustomMeasurementDefinitionViewModel customMeasurementDefinitionViewModel, IMessageDisplay MessageDisplay):
            base(MessageDisplay)
        {
            this._repository = Repository;
            DefinitionViewModel = customMeasurementDefinitionViewModel;
            Mode = ViewMode.View;

            LoadUsers();
            SetupCommands();
        }


        #region Commands
        private DelegateCommand saveUserCommand;
        private DelegateCommand deleteUserCommand;
        private DelegateCommand modifyUserCommand;
        private DelegateCommand newUserCommand;
        private DelegateCommand cancelNewUserCommand;

        public ICommand SaveUserCommand
        {
            get { return saveUserCommand; }
        }

        public ICommand DeleteUserCommand
        {
            get { return deleteUserCommand; }
        }

        public ICommand ModifyUserCommand
        {
            get { return modifyUserCommand; }
        }

        public ICommand NewUserCommand
        {
            get { return newUserCommand; }
        }

        public ICommand CancelNewUserCommand
        {
            get { return cancelNewUserCommand; }
        }

        private void SetupCommands()
        {
            saveUserCommand = new DelegateCommand(SaveNewOrModifiedUser);
            deleteUserCommand = new DelegateCommand(DeleteUser);
            modifyUserCommand = new DelegateCommand(ModifyUser);
            newUserCommand = new DelegateCommand(NewUser);
            cancelNewUserCommand = new DelegateCommand(CancelNewUser);
        }
        #endregion Commands

        #region Properties
        public CustomMeasurementDefinitionViewModel DefinitionViewModel 
        {
            get
            {
                return _definitionViewModel;
            }
            set
            {
                _definitionViewModel = value;
                NotifyPropertyChanged("DefinitionViewModel");
            }
        }

        public User SelectedUser
        {
            get
            {
                return _selectedUser;
            }

            set
            {
                _selectedUser = value;
                if (_selectedUser != null)
                {
                    Name = _selectedUser.UserName;

                    if(_selectedUser.Definitions != null)
                        DefinitionViewModel.MeasurementDefinitions = _selectedUser.Definitions.ToObservableCollection<CustomMeasurementDefinition>();
                }
                else
                {
                    Name = string.Empty;

                    _definitionViewModel.ResetContents();
                }
                NotifyPropertyChanged("SelectedUser");
            }
        }
        
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                if (value != _name)
                {
                    _name = value;
                    NotifyPropertyChanged("Name");
                }
            }
        }
        
        public ViewMode Mode
        {
            get { return _viewMode; }
            set
            {
                if (value != _viewMode)
                {
                    _viewMode = value;
                    _definitionViewModel.IsEnabled = (_viewMode == ViewMode.Edit);

                    NotifyPropertyChanged("Mode");
                    NotifyPropertyChanged("IsViewMode");
                }
            }
        }

        public bool IsViewMode
        {
            get
            {
                return _viewMode == ViewMode.View;
            }
        }

        public bool UsersLoaded
        {
            get
            {
                return Users.Count > 0;
            }
        }
        #endregion Properties

        private void LoadUsers()
        {
            Users = _repository.LoadUserList().ToObservableCollection<User>();
            SelectFirstUser();
            NotifyPropertyChanged("UsersLoaded");
        }

        private bool AddingNewUser()
        {
            return _selectedUser == null;
        }

        private void SaveNewOrModifiedUser()
        {
            User addedUser = new User(_name, CopyDefinitionListFromDefinitionViewModel());

            if (addedUser.IsValid())
            {
                if (AddingNewUser())
                {
                    Users.Add(addedUser);
                }
                else // modifying existing user
                {
                    UpdateSelectedUserFromViewFields(addedUser);
                }

                Mode = ViewMode.View;
                _repository.SaveUserList(Users);
                NotifyUsersChanged();
            }
            else
            {
                ShowValidationFailures(addedUser);
            }
            
        }

        private void UpdateSelectedUserFromViewFields(User modifiedUser)
        {
            _selectedUser.UserName = modifiedUser.UserName;
            _selectedUser.Definitions = modifiedUser.Definitions;
        }

        private void NotifyUsersChanged()
        {
            if (UsersChanged != null)
                UsersChanged.Invoke();
        }

        private IList<CustomMeasurementDefinition> CopyDefinitionListFromDefinitionViewModel()
        {
            IList<CustomMeasurementDefinition> definitionList = new List<CustomMeasurementDefinition>();
            foreach (CustomMeasurementDefinition definition in DefinitionViewModel.MeasurementDefinitions)
            {
                definitionList.Add(definition);
            }
            return definitionList;
        }

        private void DeleteUser()
        {
            if (SelectedUser != null)
            {
                DeleteUser(_selectedUser);
                Users.Remove(_selectedUser);
                SelectFirstUser();

                if (UsersChanged != null)
                    UsersChanged.Invoke();
            }
        }

        private void ModifyUser()
        {
            Mode = ViewMode.Edit;
        }

        private void NewUser()
        {
            Mode = ViewMode.Edit;
            SelectedUser = null;
            _definitionViewModel.ResetContents();
        }

        private void CancelNewUser()
        {
            Mode = ViewMode.View;
            _definitionViewModel.ResetContents();
            SelectFirstUser();
        }

        private void SelectFirstUser()
        {
            if(Users != null)
                if (Users.Count > 0)
                    SelectedUser = Users.First();
        }

        private void DeleteUser(User DeletedUser)
        {
            _repository.Delete(DeletedUser);
        }
    }
}
