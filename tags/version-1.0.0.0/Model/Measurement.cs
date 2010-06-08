using System;
using System.Collections.Generic;

namespace DietRecorder.Model
{
    public class Measurement: EntityBase
    {
        private const double MIN_WEIGHT = 0.1;
        private const double MAX_WEIGHT = 999;
        private const int MIN_DATE_YEAR = 1999;
        private const int MAX_DATE_YEAR = 2099;

        public List<CustomMeasurement> CustomMeasurements { get; private set; }
        public DateTime Date { get; private set; }
        public double WeightKg { get; private set; }
        public string Notes { get; private set; }

        public Measurement()
        {
            CustomMeasurements = new List<CustomMeasurement>();
        }

        public Measurement( DateTime date, double weight, string notes)
        {
            CustomMeasurements = new List<CustomMeasurement>();
            this.Date = date;
            this.WeightKg = weight;
            this.Notes = notes;
        }

        public override List<string> GetValidationFailures()
        {
            List<string> validationFailures = new List<string>();

            if(WeightKg < MIN_WEIGHT)
                validationFailures.Add(string.Format("Weight must be at least {0} Kg", MIN_WEIGHT));
            else if (WeightKg > MAX_WEIGHT)
                validationFailures.Add(string.Format("Weight cannot be more then {0} Kg", MAX_WEIGHT));
            
            if(Date.Year < MIN_DATE_YEAR)
                validationFailures.Add(string.Format("Date must be no earlier than {0}", MIN_DATE_YEAR));
            else if (Date.Year > MAX_DATE_YEAR)
                validationFailures.Add(string.Format("Date must be no later than {0}", MAX_DATE_YEAR));

            return validationFailures;
        }
    }
}
