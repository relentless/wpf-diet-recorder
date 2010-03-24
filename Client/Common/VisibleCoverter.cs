using System;
using System.Windows.Data;
using System.Windows;

namespace DietRecorder.Client.Common
{
    class VisibleCoverter: IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            // convert the date to a string
            bool visible = (bool)value;
            Visibility output;
            if(visible)
            {
                output = Visibility.Visible;
            }
            else
            {
                output = Visibility.Hidden;
            }
            return output;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return value;
        }
    }
}