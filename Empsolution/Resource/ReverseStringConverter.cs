using System.Globalization;
using System.Windows.Data;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace Empsolution.Resource
{
    public class ReverseStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType,
                              object parameter, CultureInfo culture)
        {
            string text = value?.ToString() ?? "";
            char[] chars = text.ToCharArray();
            Array.Reverse(chars);
            return new string(chars);
        }

        public object ConvertBack(object value, Type targetType,
                                  object parameter, CultureInfo culture)
        {
            string text = value?.ToString() ?? "";
            char[] chars = text.ToCharArray();
            Array.Reverse(chars);
            return new string(chars);
        }
    }
}

