using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace Empsolution.Resource
{
    public class IntToBoolConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            var fstValue = values[0].ToString();
            var scdValue = values[1].ToString();

            return !string.IsNullOrEmpty(fstValue) && !string.IsNullOrEmpty(scdValue);

        }

        public object[] ConvertBack(object values, Type[] targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}

