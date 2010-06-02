using System;
using System.Windows.Data;
using System.Windows;
using System.Windows.Media;

namespace DietRecorder.Client.Common.Converters
{
    class WarningColourConverter: IValueConverter {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture) {
            bool formatIsCorrect = (bool)value;
            return formatIsCorrect ? Colors.White.ToString() : Colors.Red.ToString();
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return value;
        }
    }
}
