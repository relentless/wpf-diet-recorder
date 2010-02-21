using System;
using System.Collections.Generic;
using DietRecorder.Model;
using Db4objects.Db4o;
using Db4objects.Db4o.Config;

namespace DietRecorder.DataAccess
{
    public class Repository: IRepository
    {
        public MeasurementList Load()
        {
            using (IObjectContainer database = Db4oEmbedded.OpenFile(Db4oEmbedded.NewConfiguration(), "DietDB.db4o"))
            {
                IList<MeasurementList> measurementLists = database.Query<MeasurementList>();

                if (measurementLists.Count == 0)
                {
                    return null;
                }
                else if (measurementLists.Count == 1)
                {
                    return measurementLists[0];
                }
                else
                {
                    throw new ApplicationException("Database Error: Incorrect number of measurement lists found");
                }
            }
        }

        public void Save(MeasurementList measurements)
        {
            using (IObjectContainer database = Db4oEmbedded.OpenFile(Db4oEmbedded.NewConfiguration(), "DietDB.db4o"))
            {
                DeleteExistingMeasurementLists(database);

                database.Store(measurements);
            }
        }

        private void DeleteExistingMeasurementLists(IObjectContainer database)
        {
            IList<MeasurementList> currectDBItems = database.Query<MeasurementList>();

            foreach (MeasurementList measurementList in currectDBItems)
            {
                foreach (Measurement measurement in measurementList)
                {
                    database.Delete(measurement);
                }

                database.Delete(measurementList);
            }
        }
    }
}
