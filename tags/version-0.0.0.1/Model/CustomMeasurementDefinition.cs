using System.ComponentModel;
using System.Collections.Generic;

namespace DietRecorder.Model
{
    public class CustomMeasurementDefinition:INotifyPropertyChanged
    {
        private string name;
        private MeasurementType type;

        private const int MIN_NAME_CHARS = 1;
        private const int MAX_NAME_CHARS = 40;

        public CustomMeasurementDefinition(string Name, MeasurementType Type)
        {
            name = Name;
            type = Type;
        }

        public CustomMeasurementDefinition()
        {}

        public void SetDefaultValues()
        {
            Name = string.Empty;
            Type = MeasurementType.Text;
        }

        public CustomMeasurementDefinition Clone()
        {
            return new CustomMeasurementDefinition(Name, Type);
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
        public MeasurementType Type 
        {
            get
            {
                return type;
            }

            set
            {
                if (value != type)
                {
                    type = value;
                    NotifyPropertyChanged("Type");
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

        public List<string> GetValidationFailures()
        {
            List<string> validationFailures = new List<string>();

            if (name.Length < MIN_NAME_CHARS)
                validationFailures.Add(string.Format("Name must be at least {0} character long", MIN_NAME_CHARS));
            else if (name.Length > MAX_NAME_CHARS)
                validationFailures.Add(string.Format("Name cannot be longer than {0} characters", MAX_NAME_CHARS));

            return validationFailures;
        }
    }
}
