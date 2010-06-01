using System;
using DietRecorder.Model;

namespace DietRecorder.Common
{
    public interface IMeasurementFactory
    {
        Measurement Create(DateTime date, double weight, string notes);
        Measurement Create();
    }
}
