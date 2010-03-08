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
        private Measurement measurement;
        private UserList userList;
        private User selectedUser;

        public DetailsListPresenter(DetailsList view, IDietLogic logic)
        {
            this.view = view;
            view.Presenter = this;
            this.dietLogic = logic;

            measurement = new Measurement();
            measurement.SetDefaultValues();

            LoadUserList();
        }

        private void LoadUserList()
        {
            userList = dietLogic.LoadUserList();
        }

        public void DisplayView()
        {
            view.SetUserBinding(userList);
            view.SetBindingForFields(measurement);
            view.Show();
        }

        public void LoadSelectedUser()
        {
            if (view.UserCombo.SelectedItem != null)
            {
                selectedUser = (User)view.UserCombo.SelectedItem;
                view.SetGridBinding(selectedUser.Measurements);
                ShowCustomMeasurementControls();
            }
            else
            {
                selectedUser = null;
                view.SetGridBinding(null);
            }
        }

        private void ShowCustomMeasurementControls()
        {
            if (selectedUser != null)
            {
                foreach (CustomMeasurementDefinition definition in selectedUser.Definitions)
                {
                    view.AddCustomMeasurementControl(definition);
                }
            }
        }

        public void AddMeasurement()
        {
            List<string> validationFailures = measurement.GetValidationFailures();

            if (validationFailures.Count == 0)
            {
                if (selectedUser != null)
                {
                    Measurement measurementToAdd = measurement.Clone();
                    measurementToAdd.CustomMeasurements = view.GetCustomMeasurements();
                    selectedUser.Measurements.Add(measurementToAdd);

                    dietLogic.SaveUserList(userList);

                    measurement.SetDefaultValues();
                    view.ClearCustomMeasurements();
                }
                else
                {
                    view.ShowMessage("Problem", "Please select a user");
                }
            }
            else
            {
                ShowValidationFailures(validationFailures);
            }
        }

        public void ShowMeasurement()
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
                dietLogic.Delete(view.MeasurementGrid.SelectedItem);
                selectedUser.Measurements.Remove((Measurement)view.MeasurementGrid.SelectedItem);
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

            view.ShowMessage("Validation Problem", failuresMessage.ToString());
        }

        public void ShowUserView()
        {
            UserListPresenter userPresenter = new UserListPresenter(new UserListView(), dietLogic, userList);
            userPresenter.DisplayView();
        }
    }
}
