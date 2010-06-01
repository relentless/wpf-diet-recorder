using System;
using DietRecorder.Common;
using DietRecorder.Model;

namespace DietRecorder_Tests.Common
{
    class FakeMeasurementFactory: IMeasurementFactory
    {
        private Measurement _measurementToReturn;

        public FakeMeasurementFactory ( Measurement MeasurementToReturn )
	    {
            _measurementToReturn = MeasurementToReturn;
	    }

        public Measurement Create(DateTime date, double weight, string notes)
        {
            return _measurementToReturn;
        }

        public Measurement Create()
        {
            return _measurementToReturn;
        }
    }
}
