using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DietRecorder.BusinessLeyer;
using DietRecorder.Model;

namespace DietRecorder.Client
{
    public class UserListPresenter
    {
        private UserListView view;
        private IDietLogic dietLogic;
        private UserList userList;
        private User selectedUser;
        private CustomMeasurementDefinition customMeasurementDefinition;

        public UserListPresenter(UserListView view, IDietLogic dietLogic, UserList userList)
        {
            this.view = view;
            view.Presenter = this;
            this.dietLogic = dietLogic;
            this.userList = userList;

            selectedUser = new User();
            selectedUser.SetDefaultValues();

            customMeasurementDefinition = new CustomMeasurementDefinition();
            customMeasurementDefinition.SetDefaultValues();
        }

        public void DisplayView()
        {
            view.SetUserListBinding(userList);
            view.SetUserBinding(selectedUser);
            view.SetCustomMeasurementListBinding(selectedUser.Definitions);
            view.SetCustomMeasurementDefinitionBinding(customMeasurementDefinition);
            view.ShowDialog();
        }

        public void AddUser()
        {
            List<string> validationFailures = selectedUser.GetValidationFailures();

            if (validationFailures.Count == 0)
            {
                User userToAdd = selectedUser.Clone();
                userList.Add(userToAdd);
                dietLogic.SaveUserList(userList);
                selectedUser.SetDefaultValues();
            }
            else
            {
                ShowValidationFailures(validationFailures);
            }
        }

        public void DeleteUser()
        {
            if (view.UserList.SelectedItem != null)
            {
                dietLogic.Delete(view.UserList.SelectedItem);
                userList.Remove((User)view.UserList.SelectedItem);
            }
        }

        public void DisplayUser()
        {
            if (view.UserList.SelectedItem != null)
            {
                selectedUser.SetValues((User)view.UserList.SelectedItem);
            }
            else
            {
                selectedUser = null;
            }
        }

        public void AddMeasurementDefinition()
        {
            if (selectedUser != null)
            {
                List<string> validationFailures = customMeasurementDefinition.GetValidationFailures();

                if (validationFailures.Count == 0)
                {
                    CustomMeasurementDefinition definitionToAdd = customMeasurementDefinition.Clone();
                    selectedUser.Definitions.Add(definitionToAdd);
                    dietLogic.SaveUserList(userList);
                    customMeasurementDefinition.SetDefaultValues();
                }
                else
                {
                    ShowValidationFailures(validationFailures);
                }
            }
            else
            {
                view.ShowMessage("Problem", "Please select a user");
            }
        }

        public void DeleteMeasurementDefinition()
        {
            if (view.CustomMeasurementList.SelectedItem != null)
            {
                if (selectedUser != null)
                {
                    dietLogic.Delete(view.CustomMeasurementList.SelectedItem);
                    selectedUser.Definitions.Remove((CustomMeasurementDefinition)view.CustomMeasurementList.SelectedItem);
                }
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
    }
}
