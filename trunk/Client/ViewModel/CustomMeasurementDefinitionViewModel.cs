using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using DietRecorder.BusinessLayer;
using DietRecorder.Model;
using System.Windows.Input;
using System.Text;

namespace DietRecorder.Client.ViewModel
{
    public class CustomMeasurementDefinitionViewModel:INotifyPropertyChanged
    {
        private string definitionName = string.Empty;
        private MeasurementType measurementType = MeasurementType.Text;
        private string errorMessage = string.Empty;
        private bool isError = false;
        public CustomMeasurementDefinition SelectedDefinition { get; set; }

        public CustomMeasurementDefinitionViewModel()
        {}

        public ObservableCollection<CustomMeasurementDefinition> MeasurementDefinitions { get; set; }

        public string DefinitionName
        {
            get
            {
                return definitionName;
            }
            set
            {
                if (value != definitionName)
                {
                    definitionName = value;
                    NotifyPropertyChanged("DefinitionName");
                }
            }
        }

        public MeasurementType MeasurementType
        {
            get
            {
                return measurementType;
            }
            set
            {
                if (value != measurementType)
                {
                    measurementType = value;
                    NotifyPropertyChanged("MeasurementType");
                }
            }
        }

        public string ErrorMessage
        {
            get
            {
                return errorMessage;
            }
            set
            {
                if (value != errorMessage)
                {
                    errorMessage = value;
                    NotifyPropertyChanged("ErrorMessage");
                }
            }
        }

        public bool IsError
        {
            get
            {
                return isError;
            }
            set
            {
                if (value != isError)
                {
                    isError = value;
                    NotifyPropertyChanged("IsError");
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(string PropertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(PropertyName));
            }
        }

        private void AddMeasurementDefinition()
        {
            CustomMeasurementDefinition newDefitition = new CustomMeasurementDefinition(definitionName, measurementType);
            List<string> validationFailures = newDefitition.GetValidationFailures();

            if (validationFailures.Count == 0)
            {
                MeasurementDefinitions.Add(newDefitition);
                SetDefaultValues();
                
            }
            else
            {
                ShowValidationFailures(validationFailures);
            }
        }

        public void RemoveMeasurementDefinition()
        {
            if (SelectedDefinition != null)
            {
                MeasurementDefinitions.Remove(SelectedDefinition);
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

            ErrorMessage = failuresMessage.ToString();
            IsError = true;
        }

        private void SetDefaultValues()
        {
            DefinitionName = string.Empty;
            MeasurementType = MeasurementType.Text;
        }

        private void AcceptErrorMessage()
        {
            IsError = false;
            ErrorMessage = string.Empty;
        }

        #region Add Definition
        private class AddDefinitionCommand : ICommand
        {
            private CustomMeasurementDefinitionViewModel viewModel;

            public AddDefinitionCommand(CustomMeasurementDefinitionViewModel viewModel)
            {
                this.viewModel = viewModel;
            }

            public bool CanExecute(object parameter)
            {
                return true;
            }

            public event EventHandler CanExecuteChanged;

            public void Execute(object parameter)
            {
                viewModel.AddMeasurementDefinition();
            }
        }

        private AddDefinitionCommand addDefinitionCommand;

        public ICommand AddDefinition
        {
            get
            {
                if (addDefinitionCommand == null)
                {
                    addDefinitionCommand = new AddDefinitionCommand(this);
                }
                return addDefinitionCommand;
            }
        }
        #endregion Add Definition

        #region Remove Definition
        private class RemoveDefinitionCommand : ICommand
        {
            private CustomMeasurementDefinitionViewModel viewModel;

            public RemoveDefinitionCommand(CustomMeasurementDefinitionViewModel viewModel)
            {
                this.viewModel = viewModel;
            }

            public bool CanExecute(object parameter)
            {
                return true;
            }

            public event EventHandler CanExecuteChanged;

            public void Execute(object parameter)
            {
                viewModel.RemoveMeasurementDefinition();
            }
        }

        private RemoveDefinitionCommand removeDefinitionCommand;

        public ICommand RemoveDefinition
        {
            get
            {
                if (removeDefinitionCommand == null)
                {
                    removeDefinitionCommand = new RemoveDefinitionCommand(this);
                }
                return removeDefinitionCommand;
            }
        }
        #endregion Remove Definition

        #region Accept Error
        private class AcceptErrorCommand : ICommand
        {
            private CustomMeasurementDefinitionViewModel viewModel;

            public AcceptErrorCommand(CustomMeasurementDefinitionViewModel viewModel)
            {
                this.viewModel = viewModel;
            }

            public bool CanExecute(object parameter)
            {
                return true;
            }

            public event EventHandler CanExecuteChanged;

            public void Execute(object parameter)
            {
                viewModel.AcceptErrorMessage();
            }
        }

        private AcceptErrorCommand acceptErrorCommand;

        public ICommand AcceptError
        {
            get
            {
                if (acceptErrorCommand == null)
                {
                    acceptErrorCommand = new AcceptErrorCommand(this);
                }
                return acceptErrorCommand;
            }
        }
        #endregion Accept Error
    }
}
