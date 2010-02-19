using System;
using System.Collections.Generic;
using DietRecorder.Model;

namespace DietRecorder.BusinessLeyer
{
    public interface IDietLogic
    {
        MeasurementList LoadMeasurementList();
        void SaveMeasurementList(MeasurementList measurements);
    }
}
