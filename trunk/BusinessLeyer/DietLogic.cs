using System;
using System.Collections.Generic;
using DietRecorder.Model;
using DietRecorder.DataAccess;

namespace DietRecorder.BusinessLeyer
{
    public class DietLogic: IDietLogic
    {
        private IRepository repository;

        public DietLogic(IRepository repository)
        {
            this.repository = repository;
        }

        public MeasurementList LoadMeasurementList()
        {
            MeasurementList measurements = repository.Load();

            if (measurements != null)
                return measurements;
            else
                return new MeasurementList();
        }

        public void SaveMeasurementList(MeasurementList measurements)
        {
            repository.Save(measurements);
        }

        public void DeleteMeasurement(Measurement measurement)
        {
            repository.Delete(measurement);
        }
    }
}
