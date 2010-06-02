using System;
using System.ComponentModel;
using System.Text;
using DietRecorder.Model;
using DietRecorder.Client.Common;

namespace DietRecorder.Client.ViewModel
{
    public class ViewModelBase : INotifyPropertyChanged
    {
        private IMessageDisplay _messageDisplay;

        protected ViewModelBase (IMessageDisplay MessageDisplay)
	    {
            _messageDisplay = MessageDisplay;           
	    }   

        public event PropertyChangedEventHandler PropertyChanged;

        protected void NotifyPropertyChanged(string PropertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(PropertyName));
            }
        }

        protected void ShowValidationFailures(EntityBase entity)
        {
            StringBuilder validationMessage = new StringBuilder();
            foreach (string failureMessage in entity.GetValidationFailures())
            {
                if (validationMessage.ToString() != string.Empty)
                    validationMessage.Append(Environment.NewLine);

                validationMessage.Append(failureMessage);
            }
            _messageDisplay.ShowMessage("Validation Failure", validationMessage.ToString());
        }
    }
}
