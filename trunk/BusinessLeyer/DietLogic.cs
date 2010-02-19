using System;
using System.Collections.Generic;
using DietRecorder.Model;
using DietRecorder.DataAccess;

namespace DietRecorder.BusinessLeyer
{
    public class DietLogic: IDietLogic
    {
        public MeasurementList LoadMeasurementList()
        {
            return new MeasurementList();
        }

        public void SaveMeasurementList(MeasurementList measurements)
        {
            throw new NotImplementedException();
        }
    }
}
