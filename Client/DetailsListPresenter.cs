using System;
using System.Text;
using System.Collections.Generic;
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
                Measurement listMeasurement = measurement.Clone();
                measurements.Add(listMeasurement);

                dietLogic.SaveMeasurementList(measurements);

                measurement.SetDefaultValues();
            }
            else
            {
                ShowValidationFailures(validationFailures);
            }
        }

        public void ListSelectionChanged()
        {
            if (view.MeasurementGrid.SelectedItem != null)
            {
                Measurement selectedMeasurement = (Measurement)view.MeasurementGrid.SelectedItem;
                measurement.SetValues(selectedMeasurement);
            }
        }

        public void DeleteMeasurement()
        {
            if (view.MeasurementGrid.SelectedItem != null)
            {
                dietLogic.DeleteMeasurement((Measurement)view.MeasurementGrid.SelectedItem);
                measurements.Remove((Measurement)view.MeasurementGrid.SelectedItem);
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

        public void ShowUserView()
        {
            UserListPresenter userPresenter = new UserListPresenter(new UserListView(), dietLogic);
            userPresenter.DisplayView();
        }
    }
}
