using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using DietRecorder.Model;

namespace DietRecorder.Client.ViewModel
{
    class UserViewModel: INotifyPropertyChanged
    {

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
