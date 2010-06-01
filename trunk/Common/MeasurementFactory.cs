using System;
using DietRecorder.Model;

namespace DietRecorder.Common
{
    public class MeasurementFactory: IMeasurementFactory
    {
        public Measurement Create(DateTime date, double weight, string notes)
        {
            return new Measurement(date, weight, notes);
        }

        public Measurement Create()
        {
            return new Measurement();
        }
    }
}
