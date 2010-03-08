using System;
using System.Collections.Generic;

namespace DietRecorder.Model
{
    public class User
    {
        public User(string name)
        {
            UserName = name;
            Measurements = new MeasurementList();
            Definitions = new CustomMeasurementDefinitionList();
        }

        public string UserName { get; set; }
        public MeasurementList Measurements { get; set; }
        public CustomMeasurementDefinitionList Definitions { get; set; }
    }
}
