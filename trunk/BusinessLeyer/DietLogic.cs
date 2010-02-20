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
            MeasurementList measurements = null;

            try
            {
                measurements = repository.Load();
            }
            catch (Exception)
            { }

            if (measurements != null)
                return measurements;
            else
                return new MeasurementList();
        }

        public void SaveMeasurementList(MeasurementList measurements)
        {
            try
            {
                repository.Save(measurements);
            }
            catch (Exception)
            { }
        }
    }
}
