using System;
using System.Collections.Generic;
using DietRecorder.Model;

namespace DietRecorder.DataAccess
{
    public interface IRepository
    {
        MeasurementList Load();
        void Save(MeasurementList measurements);
        void Delete(Measurement measurement);

    }
}
