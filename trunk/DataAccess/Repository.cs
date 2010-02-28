using System;
using System.Collections.Generic;
using DietRecorder.Model;
using Db4objects.Db4o;
using Db4objects.Db4o.Config;

namespace DietRecorder.DataAccess
{
    public class Repository: IRepository, IDisposable
    {
        private static IObjectContainer database = Db4oEmbedded.OpenFile(Db4oEmbedded.NewConfiguration(), "DietDB.db4o");

        public MeasurementList Load()
        {
            IList<Measurement> measurements = database.Query<Measurement>();

            if (measurements.Count == 0)
            {
                return null;
            }
            else
            {
                MeasurementList measurementList = new MeasurementList();

                foreach (Measurement measurement in measurements)
                {
                    measurementList.Add(measurement);
                }

                return measurementList;
            }
        }

        public void Save(MeasurementList measurements)
        {
            foreach (Measurement measurement in measurements)
            {
                database.Store(measurement);
            }
        }

        public void Delete(Measurement measurement)
        {
            database.Delete(measurement);
        }

        public void Dispose()
        {
            database.Close();
        }
    }
}
