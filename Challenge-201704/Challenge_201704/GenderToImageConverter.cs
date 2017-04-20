using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace Challenge_201704
{
    class GenderToImageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string gender = System.Convert.ToString(value);
            if ("male".Equals(gender))
            {
                return "https://cdn4.iconfinder.com/data/icons/universal-7/614/14_-_Male-128.png";
            }
            else
            {
                return "https://cdn2.iconfinder.com/data/icons/bitsies/128/Female-128.png";
            }

        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
