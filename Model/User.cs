using System;
using System.ComponentModel;
using System.Collections.Generic;

namespace DietRecorder.Model
{
    public class User: INotifyPropertyChanged
    {
        private string userName;
        private MeasurementList measurements = new MeasurementList();
        private CustomMeasurementDefinitionList definitions = new CustomMeasurementDefinitionList();

        private const int MIN_NAME_CHARS = 1;
        private const int MAX_NAME_CHARS = 40;

        public User(string name, MeasurementList measurementList, CustomMeasurementDefinitionList definitionList)
        {
            UserName = name;
            Measurements = measurementList;
            Definitions = definitionList;
        }

        public User()
        {}

        public void SetDefaultValues()
        {
            UserName = string.Empty;
            Measurements.Clear();
            Definitions.Clear();
        }

        public User Clone()
        {
            MeasurementList clonedMeasurements = new MeasurementList();
            CustomMeasurementDefinitionList clondDefinitions = new CustomMeasurementDefinitionList();

            foreach (Measurement measurement in measurements)
            {
                clonedMeasurements.Add(measurement);
            }

            foreach (CustomMeasurementDefinition definition in definitions)
            {
                clondDefinitions.Add(definition);
            }

            return new User(userName, clonedMeasurements, clondDefinitions);
        }

        public void SetValues(User user)
        {
            UserName = user.UserName;

            measurements.Clear();
            foreach (Measurement measurement in user.Measurements)
            {
                measurements.Add(measurement);
            }

            definitions.Clear();
            foreach (CustomMeasurementDefinition definition in user.Definitions)
            {
                definitions.Add(definition);
            }
        }

        public string UserName
        {
            get
            {
                return userName;
            }
            set
            {
                if (value != userName)
                {
                    userName = value;
                    NotifyPropertyChanged("UserName");
                }
            }
        }

        public MeasurementList Measurements
        {
            get
            {
                return measurements;
            }
            set
            {
                measurements = value;
            }
        }


        public CustomMeasurementDefinitionList Definitions
        {
            get
            {
                return definitions;
            }
            set
            {
                definitions = value;
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

        public List<string> GetValidationFailures()
        {
            List<string> validationFailures = new List<string>();

            if (userName.Length < MIN_NAME_CHARS)
                validationFailures.Add(string.Format("UserName must be at least {0} character long", MIN_NAME_CHARS));
            else if (userName.Length > MAX_NAME_CHARS)
                validationFailures.Add(string.Format("UserName cannot be longer than {0} characters", MAX_NAME_CHARS));

            return validationFailures;
        }
    }
}
