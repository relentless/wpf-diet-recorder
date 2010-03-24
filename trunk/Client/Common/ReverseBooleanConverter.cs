using System;
using System.Windows.Data;

namespace DietRecorder.Client.Common
{
    class ReverseBooleanConverter:IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            // convert the date to a string
            bool original = (bool)value;
 
            return !original;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return value;
        }
    }
}
