using System;
using System.Collections.Generic;

namespace DietRecorder.Model
{
    public class User
    {
        //private List<CustomMeasurementDefinition> definitions;

        public User(string name)
        {
            UserName = name;
            Measurements = new MeasurementList();
        }

        public string UserName { get; set; }
        public MeasurementList Measurements { get; set; }
    }
}
