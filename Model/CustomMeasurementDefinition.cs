using System.ComponentModel;
using System.Collections.Generic;

namespace DietRecorder.Model
{
    public class CustomMeasurementDefinition:EntityBase
    {
        private const int MIN_NAME_CHARS = 1;
        private const int MAX_NAME_CHARS = 40;

        public string Name { get; private set; }
        public MeasurementType Type { get; private set; }

        public CustomMeasurementDefinition(string Name, MeasurementType Type)
        {
            this.Name = Name;
            this.Type = Type;
        }

        public void SetDefaultValues()
        {
            Name = string.Empty;
            Type = MeasurementType.Text;
        }

        public override List<string> GetValidationFailures()
        {
            List<string> validationFailures = new List<string>();

            if (Name.Length < MIN_NAME_CHARS)
                validationFailures.Add(string.Format("Measurement Name must be at least {0} character long", MIN_NAME_CHARS));
            else if (Name.Length > MAX_NAME_CHARS)
                validationFailures.Add(string.Format("Measurement Name cannot be longer than {0} characters", MAX_NAME_CHARS));

            return validationFailures;
        }
    }
}
