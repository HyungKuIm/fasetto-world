using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;

namespace fasetto_world
{
    public class BooleanToColorConverter : IValueConverter
    {
        public static BooleanToColorConverter Instance = new BooleanToColorConverter();
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            
                return (bool)value ? new SolidColorBrush(Colors.Green) : new SolidColorBrush(Colors.Red);
           
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
