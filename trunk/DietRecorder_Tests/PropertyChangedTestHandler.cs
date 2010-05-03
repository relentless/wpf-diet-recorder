using System.ComponentModel;

namespace DietRecorder_Tests
{
    public class PropertyChangedTestHandler
    {
        public string PropertyName = string.Empty;

        public void HandlePropertyChanged(object sender, PropertyChangedEventArgs eventArgs)
        {
            PropertyName = eventArgs.PropertyName;
        }
    }
}
