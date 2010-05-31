using System;
using System.Windows.Data;
using System.Windows;
using System.Windows.Media;

namespace DietRecorder.Client.Common {
    class WarningColourConverter: IValueConverter {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture) {
            bool formatIsCorrect = (bool)value;
            string output;
            if (formatIsCorrect) {
                output = Colors.White.ToString();
            }
            else {
                output = Colors.Red.ToString();
            }
            return output;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture) {
            return value;
        }
    }
}
