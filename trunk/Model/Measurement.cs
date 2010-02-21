using System;
using System.ComponentModel;
using System.Collections.Generic;

namespace DietRecorder.Model
{
    public class Measurement: INotifyPropertyChanged
    {
        private string name;
        private DateTime date;
        private double weightKg;

        private const double MIN_WEIGHT = 0.1;
        private const double MAX_WEIGHT = 999;
        private readonly DateTime MIN_DATE = new DateTime(1999, 1, 1);
        private readonly DateTime MAX_DATE = new DateTime(2099, 12, 31);
        private const int MIN_NAME_CHARS = 1;
        private const int MAX_NAME_CHARS = 99;

        //needed for the new measurement in the view
        public Measurement()
        {}

        public Measurement(string name, DateTime date, double weight)
        {
            this.Name = name;
            this.Date = date;
            this.WeightKg = weight;
        }

        public void SetDefaultValues()
        {
            Name = string.Empty;
            Date = DateTime.Now.Date;
            WeightKg = 0;
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

        public List<string> GetValidationFailures()
        {
            List<string> validationFailures = new List<string>();

            if (name == null)
                validationFailures.Add(string.Format("Name must be at least {0} character(s)", MIN_NAME_CHARS));
            else if (name.Length < MIN_NAME_CHARS)
                validationFailures.Add(string.Format("Name must be at least {0} character(s)", MIN_NAME_CHARS));
            else if(name.Length > MAX_NAME_CHARS)
                validationFailures.Add(string.Format("Name cannot be more then {0} characters", MAX_NAME_CHARS));

            if(weightKg < MIN_WEIGHT)
                validationFailures.Add(string.Format("Weight must be at least {0} Kg", MIN_WEIGHT));
            else if (weightKg > MAX_WEIGHT)
                validationFailures.Add(string.Format("Weight cannot be more then {0} Kg", MAX_WEIGHT));

            if(date < MIN_DATE)
                validationFailures.Add(string.Format("Date must be at no earlier than {0}", MIN_DATE.ToShortDateString()));
            else if (date > MAX_DATE)
                validationFailures.Add(string.Format("Date must be at no later than {0}", MAX_DATE.ToShortDateString()));

            return validationFailures;
        }
    }
}
