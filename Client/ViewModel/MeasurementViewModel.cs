using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using DietRecorder.Model;
using DietRecorder.Client.Common;
using System.Windows.Input;

namespace DietRecorder.Client.ViewModel
{
    class MeasurementViewModel: INotifyPropertyChanged
    {
        private DateTime measurementDate;
        private double weightKg;
        private string notes;
        private User selectedUser;
        //public ObservableCollection<Measurement> measurements;
        public ObservableCollection<User> Users { get; set; }
        public Measurement SelectedMeasurement { get; set; }

        public event Action MeasurementAdded;
        public event Action<Measurement> MeasurementRemoved;

        private void NotifyMeasurementAdded()
        {
            if (MeasurementAdded != null)
                MeasurementAdded.Invoke();
        }

        private void NotifyMeasurementRemoved(Measurement RemovedMeasurement)
        {
            if (MeasurementRemoved != null)
                MeasurementRemoved.Invoke(RemovedMeasurement);
        }

        public MeasurementViewModel()
        {
            SetupCommands();
        }

        private void SetupCommands()
        {
            addMeasurementCommand = new DelegateCommand(AddMeasurement);
            removeMeasurementCommand = new DelegateCommand(RemoveMeasurement);
        }

        private void AddMeasurement()
        {
            Measurement newMeasurement = new Measurement(measurementDate, weightKg, notes);
            selectedUser.Measurements.Add(newMeasurement);
            NotifyPropertyChanged("Measurements");
            NotifyMeasurementAdded();
        }

        private void RemoveMeasurement()
        {
            NotifyMeasurementRemoved(SelectedMeasurement);
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

        #region Properties with NotifyProperty
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
        #endregion Properties with NotifyProperty

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
