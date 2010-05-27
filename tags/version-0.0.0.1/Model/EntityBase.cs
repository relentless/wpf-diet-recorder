using System.Collections.Generic;

namespace DietRecorder.Model
{
    public abstract class EntityBase
    {
        public bool IsValid()
        {
            return GetValidationFailures().Count == 0;
        }

        public abstract List<string> GetValidationFailures();
    }
}
