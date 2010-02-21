﻿using System;
using System.Windows.Data;

namespace DietRecorder.Client.Common
{
    public class DateConverter: IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            // convert the date to a string
            DateTime date = (DateTime)value;
            string output = date.ToShortDateString();
            return output;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            string dateValue = value.ToString();
            DateTime date = DateTime.Parse(dateValue);
            return date;
        }
    }
}
