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
        private ObservableCollection<CustomMeasurementDefinition> _measurementDefinitions = new ObservableCollection<CustomMeasurementDefinition>();
        private string _definitionName = string.Empty;
        private MeasurementType _measurementType = MeasurementType.Text;
        private string _errorMessage = string.Empty;
        private IMessageDisplay _messageDisplay;
        private bool _isEnabled;
        public CustomMeasurementDefinition SelectedDefinition { get; set; }

        public CustomMeasurementDefinitionViewModel(IMessageDisplay MessageDisplay):base(MessageDisplay)
        {
            _messageDisplay = MessageDisplay;
            SetupCommands();
        }

        #region Commands
        private DelegateCommand addDefinitionCommand;
        private DelegateCommand removeDefinitionCommand;

        public ICommand AddDefinitionCommand
        {
            get { return addDefinitionCommand; }
        }

        public ICommand RemoveDefinitionCommand
        {
            get { return removeDefinitionCommand; }
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
            _measurementDefinitions.Clear();
        }

        private void SetupCommands()
        {
            addDefinitionCommand = new DelegateCommand(AddMeasurementDefinition);
            removeDefinitionCommand = new DelegateCommand(RemoveMeasurementDefinition);
        }

        private void AddMeasurementDefinition()
        {
            CustomMeasurementDefinition newDefitition = new CustomMeasurementDefinition(_definitionName, _measurementType);

            if (newDefitition.IsValid())
            {
                MeasurementDefinitions.Add(newDefitition);
                SetDefaultValues();
            }
            else
            {
                ShowValidationFailures(newDefitition.GetValidationFailures());
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

            _messageDisplay.ShowMessage("Validation Failure", failuresMessage.ToString());
        }

        private void SetDefaultValues()
        {
            DefinitionName = string.Empty;
            MeasurementType = MeasurementType.Text;
        }
    }
}
