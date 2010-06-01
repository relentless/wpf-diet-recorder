using System;
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

        public UserViewModel(IRepository Repository, CustomMeasurementDefinitionViewModel customMeasurementDefinitionViewModel)
        {
            this._repository = Repository;
            LoadUsers();
            SetupCommands();
            DefinitionViewModel = customMeasurementDefinitionViewModel;
            
            Mode = ViewMode.View;
        }


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

        private void SetupCommands()
        {
            addUserCommand = new DelegateCommand(AddUser);
            deleteUserCommand = new DelegateCommand(DeleteUser);
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
                    DefinitionViewModel.MeasurementDefinitions = _selectedUser.Definitions.ToObservableCollection<CustomMeasurementDefinition>();
                    _definitionViewModel.IsEnabled = true;
                }
                else
                {
                    _definitionViewModel.ResetContents();
                    _definitionViewModel.IsEnabled = false;
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
            set
            {
                if (value != _viewMode)
                {
                    _viewMode = value;
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
                return _viewMode == ViewMode.View;
            }
        }

        public bool AddUserButtonsVisible
        {
            get
            {
                return _viewMode == ViewMode.Edit;
            }
        }

        public bool NameBoxEditable
        {
            get
            {
                return _viewMode == ViewMode.Edit;
            }
        }
        #endregion Properties

        private void LoadUsers()
        {
            Users = _repository.LoadUserList().ToObservableCollection<User>();
        }

        private void AddUser()
        {
            //User newUser = new User();
            //newUser.UserName = _name;

            IList<CustomMeasurementDefinition> definitionList = new List<CustomMeasurementDefinition>();
            foreach( CustomMeasurementDefinition definition in DefinitionViewModel.MeasurementDefinitions)
            {
                definitionList.Add(definition);
            }
            
            //newUser.Definitions = definitionList;
            User newUser = new User(_name, null, definitionList);
            Users.Add(newUser);
            Name = string.Empty;

            Mode = ViewMode.View;
            _definitionViewModel.ResetContents();
            SelectedUser = newUser;
            SaveUsers();

            if (UsersChanged != null)
                UsersChanged.Invoke();
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

        private void NewUser()
        {
            Mode = ViewMode.Edit;
            SelectedUser = null;
            _definitionViewModel.ResetContents();
            _definitionViewModel.IsEnabled = true;
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

        private void SaveUsers()
        {
            _repository.SaveUserList(Users);
        }

        private void DeleteUser(User DeletedUser)
        {
            _repository.Delete(DeletedUser);
        }
    }
}
