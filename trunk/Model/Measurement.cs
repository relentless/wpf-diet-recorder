using System;

namespace DietRecorder.Model
{
    public class Measurement
    {
        public Measurement(string name, DateTime date, double weight)
        {
            this.Name = name;
            this.Date = date;
            this.WeightKg = weight;
        }

        string Name { get; set; }
        DateTime Date { get; set; }
        double WeightKg { get; set; }
    }
}
