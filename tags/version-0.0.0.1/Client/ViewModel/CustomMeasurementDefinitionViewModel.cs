using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using DietRecorder.Model;
using System.Windows.Input;
using System.Text;
using DietRecorder.Client.Common;

namespace DietRecorder.Client.ViewModel
{
    public class CustomMeasurementDefinitionViewModel : ViewModelBase
    {
        private ObservableCollection<CustomMeasurementDefinition> measurementDefinitions;
        private string definitionName = string.Empty;
        private MeasurementType measurementType = MeasurementType.Text;
        private string errorMessage = string.Empty;
        private bool isError = false;
        private bool isEnabled = false;
        public CustomMeasurementDefinition SelectedDefinition { get; set; }

        #region Commands
        private DelegateCommand acceptErrorCommand;
        private DelegateCommand addDefinitionCommand;
        private DelegateCommand removeDefinitionCommand;

        public ICommand AcceptErrorCommand
        {
            get { return acceptErrorCommand; }
        }

        public ICommand AddDefinitionCommand
        {
            get { return addDefinitionCommand; }
        }

        public ICommand RemoveDefinitionCommand
        {
            get { return removeDefinitionCommand; }
        }

        public CustomMeasurementDefinitionViewModel()
        {
            SetupCommands();
        }
        #endregion Commands

        #region Properties with NotifyProperty
        public ObservableCollection<CustomMeasurementDefinition> MeasurementDefinitions 
        {
            get
            {
                return measurementDefinitions;
            }

            set
            {
                measurementDefinitions = value;
                NotifyPropertyChanged("MeasurementDefinitions");
            }
        }

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

        public bool IsEnabled
        {
            get
            {
                return isEnabled;
            }
            set
            {
                if (value != isEnabled)
                {
                    isEnabled = value;
                    NotifyPropertyChanged("IsEnabled");
                }
            }
        }
        #endregion Properties with NotifyProperty


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

        public void AcceptErrorMessage()
        {
            IsError = false;
            ErrorMessage = string.Empty;
        }

        public void SetupCommands()
        {
            acceptErrorCommand = new DelegateCommand(this.AcceptErrorMessage);
            addDefinitionCommand = new DelegateCommand(AddMeasurementDefinition);
            removeDefinitionCommand = new DelegateCommand(RemoveMeasurementDefinition);
        }

        public void ResetContents()
        {
            SetDefaultValues();
            //measurementDefinitions.Clear();
        }
    }
}
