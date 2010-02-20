using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using DietRecorder.Model;
using DietRecorder.BusinessLeyer;

namespace DietRecorder.Client
{
    public class DetailsListPresenter
    {
        private DetailsList view;
        private IDietLogic dietLogic;
        private MeasurementList measurements;
        private Measurement measurement = new Measurement();

        public DetailsListPresenter(DetailsList view, IDietLogic logic)
        {
            this.view = view;
            view.Presenter = this;
            this.dietLogic = logic;
        }

        public MeasurementList Measurements
        {
            get
            {
                return measurements;
            }
        }

        public void DisplayView()
        {
            measurements = dietLogic.LoadMeasurementList();
            view.SetGridBinding(measurements);
            view.SetBindingForFields(measurement);
            view.Show();
        }

        public void AddMeasurement()
        {
            try
            {
                Measurement listMeasurement = new Measurement(measurement.Name, measurement.Date, measurement.WeightKg);
                measurements.Add(listMeasurement);
                
                dietLogic.SaveMeasurementList(measurements);

                ResetMeasurement();
            }
            catch (FormatException)
            {
                view.ShowMesage("Write it proper, would ya!");
            }
        }

        private void ResetMeasurement()
        {
            measurement.Name = string.Empty;
            measurement.Date = new DateTime();
            measurement.WeightKg = 0;
        }
    }
}
