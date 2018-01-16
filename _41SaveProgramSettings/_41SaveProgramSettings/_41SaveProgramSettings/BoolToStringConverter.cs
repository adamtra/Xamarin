using System;
using System.Globalization;
using Xamarin.Forms;

namespace _41SaveProgramSettings
{
    public class BoolToStringConverter : IValueConverter
    {
        public string TrueText { set; get; }

        public string FalseText { set; get; }

        public object Convert(object value, Type targetType,
                              object parameter, CultureInfo culture)
        {
            return (bool)value ? TrueText : FalseText;
        }

        public object ConvertBack(object value, Type targetType,
                                  object parameter, CultureInfo culture)
        {
            return false;
        }
    }
}
