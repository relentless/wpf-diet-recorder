using System;
using System.ComponentModel;
using System.Collections.Generic;

namespace DietRecorder.Model
{
    public class Measurement: INotifyPropertyChanged
    {
        private DateTime date;
        private double weightKg;
        private string notes;
        //private List<CustomMeasurement> customMeasurements;

        private const double MIN_WEIGHT = 0.1;
        private const double MAX_WEIGHT = 999;
        private const int MIN_DATE_YEAR = 1999;
        private const int MAX_DATE_YEAR = 2099;

        //needed for the new measurement in the view
        public Measurement()
        {}

        public Measurement( DateTime date, double weight, string notes)
        {
            this.Date = date;
            this.WeightKg = weight;
            this.notes = notes;
        }

        public void SetDefaultValues()
        {
            Date = DateTime.Now.Date;
            WeightKg = 0;
            Notes = string.Empty;
        }

        public Measurement Clone()
        {
            return new Measurement(date, weightKg, notes);
        }

        public void SetValues(Measurement measurement)
        {
            Notes = measurement.Notes;
            Date = measurement.Date;
            WeightKg = measurement.WeightKg;
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

        public string Notes
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

        public override string ToString()
        {
            return string.Format("On {0}, weight was {1} Kg", date, weightKg);
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

            if(weightKg < MIN_WEIGHT)
                validationFailures.Add(string.Format("Weight must be at least {0} Kg", MIN_WEIGHT));
            else if (weightKg > MAX_WEIGHT)
                validationFailures.Add(string.Format("Weight cannot be more then {0} Kg", MAX_WEIGHT));
            
            if(date.Year < MIN_DATE_YEAR)
                validationFailures.Add(string.Format("Date must be no earlier than {0}", MIN_DATE_YEAR));
            else if (date.Year > MAX_DATE_YEAR)
                validationFailures.Add(string.Format("Date must be no later than {0}", MAX_DATE_YEAR));

            return validationFailures;
        }
    }
}
