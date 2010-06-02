using System;
using System.Text;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using DietRecorder.Model;
using DietRecorder.Client.Common;
using System.Windows.Input;
using DietRecorder.DataAccess;
using DietRecorder.Common;

namespace DietRecorder.Client.ViewModel {
    public class MeasurementViewModel : ViewModelBase {
        
        private IMeasurementFactory _measurementFactory;
        private IRepository _repository;
        private Boolean _viewMode;
        private Measurement _selectedMeasurement;
        private User _selectedUser;
        private IList<User> _users;
        private string _measurementDate = string.Empty;
        private string _weightKg = string.Empty;
        private string _notes = string.Empty;

        public event Action ShowUserScreenAction;

        public MeasurementViewModel(IRepository Repository, IMessageDisplay MessageDisplay, IMeasurementFactory MeasurementFactory):
            base(MessageDisplay)
        {
            _repository = Repository;
            _measurementFactory = MeasurementFactory;
            ViewMode = true;
            SetupCommands();
            LoadUsersFromRepository();
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
                return _selectedMeasurement;
            }

            set
            {
                _selectedMeasurement = value;
                SetMeasurementFieldsFromSelectedMeasurement();
                NotifyPropertyChanged("SelectedMeasurement");
            }
        }

        private void SetMeasurementFieldsFromSelectedMeasurement()
        {
            if (_selectedMeasurement != null)
            {
                MeasurementDate = _selectedMeasurement.Date.ToShortDateString();
                WeightKg = _selectedMeasurement.WeightKg.ToString();
                Notes = _selectedMeasurement.Notes;
            }
            else
            {
                MeasurementDate = string.Empty;
                WeightKg = string.Empty;
                Notes = string.Empty;
            }
        }

        public bool ViewMode
        {
            get
            {
                return _viewMode;
            }
            set
            {
                if (value != _viewMode)
                {
                    _viewMode = value;
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
                    NotifyPropertyChanged("Notes");
                }
            }
        }

        public string WeightKg
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
                    NotifyPropertyChanged("WeightKgIsCorrectFormat");
                }
            }
        }

        public bool WeightKgIsCorrectFormat
        {
            get
            {
                try
                {
                    Convert.ToDouble(_weightKg);
                }
                catch (FormatException)
                {
                    return false;
                }

                return true;
            }
        }

        public string MeasurementDate
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
                    NotifyPropertyChanged("MeasurementDateIsCorrectFormat");
                }
            }
        }

        public bool MeasurementDateIsCorrectFormat
        {
            get
            {
                try
                {
                    Convert.ToDateTime(_measurementDate);
                }
                catch (FormatException)
                {
                    return false;
                }

                return true;
            }
        }

        public ObservableCollection<User> Users
        {
            get
            {
                return _users.ToObservableCollection<User>();
            }
        }

        public ObservableCollection<Measurement> Measurements
        {
            get
            {
                return _selectedUser.Measurements.ToObservableCollection<Measurement>();
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
                if (value != _selectedUser)
                {
                    _selectedUser = value;

                    if (_selectedUser != null)
                        SelectFirstMeasurement();

                    NotifyPropertyChanged("SelectedUser");
                    NotifyPropertyChanged("Measurements");
                }
            }
        }
        #endregion Properties

        public void LoadUsersFromRepository()
        {
            _users = _repository.LoadUserList();
            SelectFirstUser();
            NotifyPropertyChanged("Users");
        }

        private void SetupCommands()
        {
            newMeasurementCommand = new DelegateCommand(PrepareForNewMeasurement);
            removeMeasurementCommand = new DelegateCommand(RemoveMeasurement);
            addMeasurementCommand = new DelegateCommand(AddMeasurement);
            cancelNewMeasurementCommand = new DelegateCommand(CancelNewMeasurement);
            showUsersCommand = new DelegateCommand(ShowUserScreen);
        }

        private void SelectFirstUser() {
            if (_users != null)
                if (_users.Count > 0)
                    SelectedUser = _users[0];
        }

        private void SelectFirstMeasurement() {
            if (Measurements != null)
            {
                if (Measurements.Count > 0)
                {
                    SelectedMeasurement = Measurements[0];
                    return;
                }
            }

            SelectedMeasurement = null;
        }

        private void ShowUserScreen() {
            if (ShowUserScreenAction != null) {
                ShowUserScreenAction.Invoke();
            }
        }

        private void PrepareForNewMeasurement() {
            MeasurementDate = GetCurrentDate().ToShortDateString();
            WeightKg = "0";
            Notes = string.Empty;
            ViewMode = false;
        }

        private void RemoveMeasurement() {
            _repository.Delete(SelectedMeasurement);
            _selectedUser.RemoveMeasurement(SelectedMeasurement);
            _repository.SaveUserList(_users);
            SelectFirstMeasurement();
            NotifyPropertyChanged("Measurements");
        }

        private void AddMeasurement() {
            if (!MeasurementValuesAreCorrectFormat())
                return;

            Measurement addedMeasurement = _measurementFactory.Create(Convert.ToDateTime(_measurementDate), Convert.ToDouble(_weightKg), _notes);

            if (addedMeasurement.IsValid()) {
                _selectedUser.AddMeasurement(addedMeasurement);
                _repository.SaveUserList(_users);
                SelectedMeasurement = addedMeasurement;
                ViewMode = true;
                NotifyPropertyChanged("Measurements");
            }
            else {
                ShowValidationFailures(addedMeasurement);
            }
        }

        private void CancelNewMeasurement() {
            SelectedMeasurement = null;
            SelectFirstMeasurement();
            ViewMode = true;
        }

        private bool MeasurementValuesAreCorrectFormat() {
            return MeasurementDateIsCorrectFormat &&
                    WeightKgIsCorrectFormat;
        }

        protected virtual DateTime GetCurrentDate()
        {
            return DateTime.Now;
        }
    }
}
