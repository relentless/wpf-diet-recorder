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
        private ObservableCollection<CustomMeasurementDefinition> _measurementDefinitions;
        private string _definitionName = string.Empty;
        private MeasurementType _measurementType = MeasurementType.Text;
        private string _errorMessage = string.Empty;
        private bool _isError = false;
        private bool _isEnabled = false;
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

        #region Properties
        public ObservableCollection<CustomMeasurementDefinition> MeasurementDefinitions 
        {
            get
            {
                return _measurementDefinitions;
            }

            set
            {
                _measurementDefinitions = value;
                NotifyPropertyChanged("MeasurementDefinitions");
            }
        }

        public string DefinitionName
        {
            get
            {
                return _definitionName;
            }
            set
            {
                if (value != _definitionName)
                {
                    _definitionName = value;
                    NotifyPropertyChanged("DefinitionName");
                }
            }
        }

        public MeasurementType MeasurementType
        {
            get
            {
                return _measurementType;
            }
            set
            {
                if (value != _measurementType)
                {
                    _measurementType = value;
                    NotifyPropertyChanged("MeasurementType");
                }
            }
        }
        
        public string ErrorMessage
        {
            get
            {
                return _errorMessage;
            }
            set
            {
                if (value != _errorMessage)
                {
                    _errorMessage = value;
                    NotifyPropertyChanged("ErrorMessage");
                }
            }
        }

        public bool IsError
        {
            get
            {
                return _isError;
            }
            set
            {
                if (value != _isError)
                {
                    _isError = value;
                    NotifyPropertyChanged("IsError");
                }
            }
        }

        public bool IsEnabled
        {
            get
            {
                return _isEnabled;
            }
            set
            {
                if (value != _isEnabled)
                {
                    _isEnabled = value;
                    NotifyPropertyChanged("IsEnabled");
                }
            }
        }
        #endregion Properties

        public void ResetContents()
        {
            SetDefaultValues();
        }

        private void SetupCommands()
        {
            acceptErrorCommand = new DelegateCommand(this.AcceptErrorMessage);
            addDefinitionCommand = new DelegateCommand(AddMeasurementDefinition);
            removeDefinitionCommand = new DelegateCommand(RemoveMeasurementDefinition);
        }

        private void AddMeasurementDefinition()
        {
            CustomMeasurementDefinition newDefitition = new CustomMeasurementDefinition(_definitionName, _measurementType);
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

        private void RemoveMeasurementDefinition()
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
    }
}
