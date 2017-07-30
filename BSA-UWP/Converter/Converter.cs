using System;
using Windows.UI.Xaml.Data;

namespace BSA_UWP.Converter
{
    public class Converter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (value == null)
                return null;           
            
            DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
            dtDateTime = dtDateTime.AddSeconds(System.Convert.ToDouble(value.ToString())).ToLocalTime();
            return dtDateTime;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            return null;
        }
    }
}
