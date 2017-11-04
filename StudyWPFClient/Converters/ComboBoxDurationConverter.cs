using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;

namespace StudyWPFClient.Converters
{
    public class ComboBoxDurationConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null)
            {
                return ((TimeSpan)value).Hours.ToString();
            }
            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null)
            {
                int hours = System.Convert.ToInt32((value as ComboBoxItem)?.Content.ToString());
                return new TimeSpan(hours, 0, 0);
            }
            return null;
        }
    }
}
