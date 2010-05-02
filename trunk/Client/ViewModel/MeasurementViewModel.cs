using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using DietRecorder.Model;
using DietRecorder.Client.Common;
using System.Windows.Input;
using DietRecorder.DataAccess;

namespace DietRecorder.Client.ViewModel
{
    public class MeasurementViewModel: INotifyPropertyChanged
    {
        private IRepository repository;
        //private DateTime measurementDate;
        //private double weightKg;
        //private string notes;
        private Measurement selectedMeasurement;
        private User selectedUser;
        private IList<User> users;

        public event Action ShowUserScreen;

        public MeasurementViewModel(IRepository Repository)
        {
            this.repository = Repository;
            SetupCommands();
            LoadUsers();
        }

        private void LoadUsers()
        {
            users = repository.LoadUserList();
            SelectFirstUser();
            NotifyPropertyChanged("Users");
        }

        private void SelectFirstUser()
        {
            if (users != null)
                if(users.Count > 0)
                    SelectedUser = users[0];
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

        private void SaveMeasurements()
        {
            repository.SaveUserList(users);
        }

        private void RemoveMeasurement(Measurement RemovedMeasurement)
        {
            repository.Delete(RemovedMeasurement);
        }

        private void NewMeasurement()
        {
            SelectedMeasurement = null;// to de-select the selected list item
            SelectedMeasurement = new Measurement();
        }

        private void RemoveMeasurement()
        {
            //RemoveMeasurement(SelectedMeasurement);
            selectedUser.Measurements.Remove(SelectedMeasurement);
            NotifyPropertyChanged("Measurements");
        }

        private void AddMeasurement()
        {
            selectedUser.Measurements.Add(SelectedMeasurement);
            NotifyPropertyChanged("Measurements");
            //SaveMeasurements();
        }

        private void CancelNewMeasurement()
        {

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

        //public DateTime MeasurementDate
        //{
        //    get
        //    {
        //        if (SelectedMeasurement != null)
        //            return SelectedMeasurement.Date;
        //        else
        //            return new DateTime();
        //    }
        //    set
        //    {
        //    //    if (value != measurementDate)
        //    //    {
        //    //        measurementDate = value;
        //    //        NotifyPropertyChanged("MeasurementDate");
        //    //    }
        //    }
        //}

        //public double WeightKg
        //{
        //    get
        //    {
        //        if (SelectedMeasurement != null)
        //            return SelectedMeasurement.WeightKg;
        //        else
        //            return 0.0;
        //        //return weightKg;
        //    }
        //    set
        //    {
        //    //    if (value != weightKg)
        //    //    {
        //    //        weightKg = value;
        //    //        NotifyPropertyChanged("WeightKg");
        //    //    }
        //    }
        //}

        //public String Notes
        //{
        //    get
        //    {
        //        if (SelectedMeasurement != null)
        //            return SelectedMeasurement.Notes;
        //        else
        //            return string.Empty;

        //        //return notes;
        //    }
        //    set
        //    {
        //    //    if (value != notes)
        //    //    {
        //    //        notes = value;
        //    //        NotifyPropertyChanged("Notes");
        //    //    }
        //    }
        //}

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
