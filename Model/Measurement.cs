using System;
using System.ComponentModel;

namespace DietRecorder.Model
{
    public class Measurement: INotifyPropertyChanged
    {
        private string name;
        private DateTime date;
        private double weightKg;

        //needed for the new measurement in the view
        public Measurement()
        { }

        public Measurement(string name, DateTime date, double weight)
        {
            this.Name = name;
            this.Date = date;
            this.WeightKg = weight;
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

        public DateTime Date
        {
            get
            {
                return date;
            }
            set
            {
                if (value != date)
                {
                    date = value;
                    NotifyPropertyChanged("Date");
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

        public override string ToString()
        {
            return string.Format("On {0}, {1} weighed {2} Kg", date, name, weightKg);
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
