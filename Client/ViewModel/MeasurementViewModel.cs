using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using DietRecorder.Model;
using DietRecorder.Client.Common;
using System.Windows.Input;
using DietRecorder.BusinessLayer;

namespace DietRecorder.Client.ViewModel
{
    class MeasurementViewModel: INotifyPropertyChanged
    {
        private IDietLogic dietLogic;
        private DateTime measurementDate;
        private double weightKg;
        private string notes;
        private User selectedUser;
        private IList<User> users;

        public event Action ShowUserScreen;

        public MeasurementViewModel(IDietLogic dietLogic)
        {
            this.dietLogic = dietLogic;
            SetupCommands();
            LoadUsers();
        }

        private void LoadUsers()
        {
            users = dietLogic.LoadUserList();
            NotifyPropertyChanged("Users");
        }

        private void SetupCommands()
        {
            addMeasurementCommand = new DelegateCommand(AddMeasurement);
            removeMeasurementCommand = new DelegateCommand(RemoveMeasurement);
            showUsersCommand = new DelegateCommand(ShowUsers);
        }

        private void ShowUsers()
        {
            if (ShowUserScreen != null)
                ShowUserScreen.Invoke();
        }

        private void SaveMeasurements()
        {
            dietLogic.SaveUserList(users);
        }

        private void RemoveMeasurement(Measurement RemovedMeasurement)
        {
            dietLogic.Delete(RemovedMeasurement);
        }

        private void AddMeasurement()
        {
            Measurement newMeasurement = new Measurement(measurementDate, weightKg, notes);
            selectedUser.Measurements.Add(newMeasurement);
            NotifyPropertyChanged("Measurements");
            SaveMeasurements();
        }

        private void RemoveMeasurement()
        {
            RemoveMeasurement(SelectedMeasurement);
            selectedUser.Measurements.Remove(SelectedMeasurement);
            NotifyPropertyChanged("Measurements");
        }

        #region Commands
        private DelegateCommand showUsersCommand;
        private DelegateCommand addMeasurementCommand;
        private DelegateCommand removeMeasurementCommand;

        public ICommand ShowUsersCommand
        {
            get { return showUsersCommand; }
        }

        public ICommand AddMeasurementCommand
        {
            get { return addMeasurementCommand; }
        }

        public ICommand RemoveMeasurementCommand
        {
            get { return removeMeasurementCommand; }
        }
        #endregion Commands

        #region Properties

        public Measurement SelectedMeasurement { get; set; }

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

        public DateTime MeasurementDate
        {
            get
            {
                return measurementDate;
            }
            set
            {
                if (value != measurementDate)
                {
                    measurementDate = value;
                    NotifyPropertyChanged("MeasurementDate");
                }
            }
        }

        public double WeightKg
        {
            get
            {
                return weightKg;
            }
            set
            {
                if (value != weightKg)
                {
                    weightKg = value;
                    NotifyPropertyChanged("WeightKg");
                }
            }
        }

        public String Notes
        {
            get
            {
                return notes;
            }
            set
            {
                if (value != notes)
                {
                    notes = value;
                    NotifyPropertyChanged("Notes");
                }
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
                    NotifyPropertyChanged("SelectedUser");
                    NotifyPropertyChanged("Measurements");
                }
            }
        }
        #endregion Properties

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
    }
}
