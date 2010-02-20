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

        public string Name { get; set; }
        public DateTime Date { get; set; }
        public double WeightKg { get; set; }

        public override string ToString()
        {
            return string.Format("On {0}, {1} weighed {2} Kg", Date, Name, WeightKg);
        }
    }
}
