using System;
using System.ComponentModel;
using System.Collections.Generic;

namespace DietRecorder.Model
{
    public class User: EntityBase
    {
        private IList<Measurement> measurements = new List<Measurement>();
        private IList<CustomMeasurementDefinition> definitions = new List<CustomMeasurementDefinition>();

        private const int MIN_NAME_CHARS = 1;
        private const int MAX_NAME_CHARS = 40;

        public User(string name, IList<Measurement> measurementList, IList<CustomMeasurementDefinition> definitionList)
        {
            UserName = name;
            measurements = measurementList;
            definitions = definitionList;
        }

        public User(string name, IList<CustomMeasurementDefinition> definitionList):this(name, new List<Measurement>(), definitionList)
        {}

        public User()
        {}

        public void SetDefaultValues()
        {
            UserName = string.Empty;
            measurements.Clear();
            definitions.Clear();
        }

        public string UserName {get; set;}

        public IList<Measurement> Measurements
        {
            get
            {
                return measurements;
            }
        }

        public IList<CustomMeasurementDefinition> Definitions
        {
            get { return definitions; }
            set { definitions = value; }
        }

        public void AddMeasurement(Measurement measurement)
        {
            measurements.Add(measurement);
        }

        public void RemoveMeasurement(Measurement measurement)
        {
            measurements.Remove(measurement);
        }

        public override List<string> GetValidationFailures()
        {
            List<string> validationFailures = new List<string>();

            if (UserName.Length < MIN_NAME_CHARS)
                validationFailures.Add(string.Format("Name must be at least {0} character long", MIN_NAME_CHARS));
            else if (UserName.Length > MAX_NAME_CHARS)
                validationFailures.Add(string.Format("Name cannot be longer than {0} characters", MAX_NAME_CHARS));

            return validationFailures;
        }
    }
}
