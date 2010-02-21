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
        private Measurement measurement;

        public DetailsListPresenter(DetailsList view, IDietLogic logic)
        {
            this.view = view;
            view.Presenter = this;
            this.dietLogic = logic;

            measurement = new Measurement();
            measurement.SetDefaultValues();

            LoadMeasurements();
        }

        private void LoadMeasurements()
        {
            measurements = dietLogic.LoadMeasurementList();
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
            view.SetGridBinding(measurements);
            view.SetBindingForFields(measurement);
            view.Show();
        }

        public void AddMeasurement()
        {
            List<string> validationFailures = measurement.GetValidationFailures();

            if (validationFailures.Count == 0)
            {
                Measurement listMeasurement = new Measurement(measurement.Name, measurement.Date, measurement.WeightKg);
                measurements.Add(listMeasurement);

                dietLogic.SaveMeasurementList(measurements);

                measurement.SetDefaultValues();
            }
            else
            {
                ShowValidationFailures(validationFailures);
            }
        }

        private void ShowValidationFailures(List<string> validationFailures)
        {
            StringBuilder failuresMessage = new StringBuilder();
            failuresMessage.Append("Please sort out these issues:");
            failuresMessage.Append(Environment.NewLine);

            foreach (string failure in validationFailures)
            {
                failuresMessage.Append(Environment.NewLine);
                failuresMessage.Append(failure);
            }

            view.ShowMesage("Validation Problem", failuresMessage.ToString());
        }
    }
}
