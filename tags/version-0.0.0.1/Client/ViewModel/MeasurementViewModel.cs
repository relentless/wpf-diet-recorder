using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using DietRecorder.Model;
using DietRecorder.Client.Common;
using System.Windows.Input;
using DietRecorder.DataAccess;

namespace DietRecorder.Client.ViewModel
{
    public class MeasurementViewModel: ViewModelBase
    {
        private DateTime _measurementDate = DateTime.MinValue;
        private double _weightKg = 0d;
        private string _notes = string.Empty;
        private IRepository _repository;
        private Boolean viewMode;
        private Measurement selectedMeasurement;
        private User selectedUser;
        private IList<User> users;
        private IMessageDisplay messageBoxDisplayer;

        public event Action ShowUserScreen;

        public MeasurementViewModel(IRepository Repository, IMessageDisplay MessageBox)
        {
            this._repository = Repository;
            messageBoxDisplayer = MessageBox;
            ViewMode = true;
            SetupCommands();
            LoadUsers();
        }

        public MeasurementViewModel(IRepository Repository)
            : this(Repository, new MessageDisplay())
        {}

        public void LoadUsers()
        {
            users = _repository.LoadUserList();
            SelectFirstUser();
            NotifyPropertyChanged("Users");
        }

        private void SelectFirstUser()
        {
            if (users != null)
                if(users.Count > 0)
                    SelectedUser = users[0];
        }

        private void SelectFirstMeasurement()
        {
            if (Measurements != null)
                if (Measurements.Count > 0)
                    SelectedMeasurement = Measurements[0];
        }

        private void SetupCommands()
        {
            newMeasurementCommand = new DelegateCommand(NewMeasurement);
            removeMeasurementCommand = new DelegateCommand(RemoveMeasurement);
            addMeasurementCommand = new DelegateCommand(AddMeasurement);
            cancelNewMeasurementCommand = new DelegateCommand(CancelNewMeasurement);
            showUsersCommand = new DelegateCommand(ShowUsers);
        }

        private void ShowUsers()
        {
            if (ShowUserScreen != null)
            {
                ShowUserScreen.Invoke();
            }
        }

        private void NewMeasurement()
        {
            SelectedMeasurement = null;// to de-select the selected list item
            Measurement newMeasurement = new Measurement();
            newMeasurement.SetDefaultValues();
            SelectedMeasurement = newMeasurement;
            ViewMode = false;
        }

        private void RemoveMeasurement()
        {
            _repository.Delete(SelectedMeasurement);
            selectedUser.Measurements.Remove(SelectedMeasurement);
            _repository.SaveUserList(users);
            SelectFirstMeasurement();
            NotifyPropertyChanged("Measurements");
        }

        private void AddMeasurement()
        {
            if (selectedMeasurement.IsValid())
            {
                selectedUser.Measurements.Add(SelectedMeasurement);
                NotifyPropertyChanged("Measurements");
                _repository.SaveUserList(users);
                ViewMode = true;
            }
            else
            {
                string validationMessage = string.Empty;
                foreach (string failureMessage in selectedMeasurement.GetValidationFailures())
                {
                    if (validationMessage != string.Empty)
                        validationMessage += Environment.NewLine;

                    validationMessage += failureMessage;
                }
                messageBoxDisplayer.ShowMessage("Validation Failure", validationMessage);
            }
        }

        private void CancelNewMeasurement()
        {
            SelectedMeasurement = null;
            SelectFirstMeasurement();
            ViewMode = true;
        }

        #region Commands
        private DelegateCommand showUsersCommand;
        private DelegateCommand newMeasurementCommand;
        private DelegateCommand removeMeasurementCommand;
        private DelegateCommand cancelNewMeasurementCommand;
        private DelegateCommand addMeasurementCommand;

        public ICommand ShowUsersCommand
        {
            get { return showUsersCommand; }
        }

        public ICommand NewMeasurementCommand
        {
            get { return newMeasurementCommand; }
        }

        public ICommand RemoveMeasurementCommand
        {
            get { return removeMeasurementCommand; }
        }

        public ICommand AddMeasurementCommand
        {
            get { return addMeasurementCommand; }
        }

        public ICommand CancelNewMeasurementCommand
        {
            get { return cancelNewMeasurementCommand; }
        }
        #endregion Commands

        #region Properties

        public Measurement SelectedMeasurement 
        {
            get
            {
                return selectedMeasurement;
            }

            set
            {
                selectedMeasurement = value;
                NotifyPropertyChanged("SelectedMeasurement");
            }
        }

        public bool ViewMode
        {
            get
            {
                return viewMode;
            }
            set
            {
                if (value != viewMode)
                {
                    viewMode = value;
                    NotifyPropertyChanged("ViewMode");
                }
            }
        }

        public string Notes
        {
            get
            {
                return _notes;
            }
            set
            {
                if (value != _notes)
                {
                    _notes = value;
                    NotifyPropertyChanged("UserName");
                }
            }
        }

        public double WeightKg
        {
            get
            {
                return _weightKg;
            }
            set
            {
                if (value != _weightKg)
                {
                    _weightKg = value;
                    NotifyPropertyChanged("WeightKg");
                }
            }
        }

        public DateTime MeasurementDate
        {
            get
            {
                return _measurementDate;
            }
            set
            {
                if (value != _measurementDate)
                {
                    _measurementDate = value;
                    NotifyPropertyChanged("MeasurementDate");
                }
            }
        }

        public ObservableCollection<User> Users
        {
            get
            {
                return users.ToObservableCollection<User>();
            }
        }

        public ObservableCollection<Measurement> Measurements
        {
            get
            {
                return selectedUser.Measurements.ToObservableCollection<Measurement>();
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
                if (value != selectedUser)
                {
                    selectedUser = value;

                    if(selectedUser != null)
                        SelectFirstMeasurement();

                    NotifyPropertyChanged("SelectedUser");
                    NotifyPropertyChanged("Measurements");
                }
            }
        }
        #endregion Properties
    }
}
