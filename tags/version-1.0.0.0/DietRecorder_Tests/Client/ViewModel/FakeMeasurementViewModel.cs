using System;
using DietRecorder.Client.ViewModel;
using DietRecorder.DataAccess;
using DietRecorder.Common;
using Rhino.Mocks;

namespace DietRecorder_Tests.Client.ViewModel
{
    class FakeMeasurementViewModel: MeasurementViewModel
    {
        private DateTime _currentDate;

        public FakeMeasurementViewModel(DateTime currentDate):
            base(MockRepository.GenerateStub<IRepository>(), null, MockRepository.GenerateStub<IMeasurementFactory>())
        {
            _currentDate = currentDate;
        }

        protected override DateTime GetCurrentDate()
        {
            return _currentDate;
        }
    }
}
