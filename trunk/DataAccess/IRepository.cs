using System;
using System.Collections.Generic;
using DietRecorder.Model;

namespace DietRecorder.DataAccess
{
    public interface IRepository
    {
        MeasurementList Get();
        void Save(MeasurementList measurements);
    }
}
