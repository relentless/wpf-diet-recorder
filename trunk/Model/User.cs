using System;
using System.Collections.Generic;

namespace DietRecorder.Model
{
    public class User
    {
        //private List<CustomMeasurementDefinition> definitions;
        private MeasurementList measurements;

        public User(string name)
        {
            this.UserName = name;
        }

        public string UserName { get; set; }
    }
}
