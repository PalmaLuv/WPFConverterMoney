using System.Globalization;
using System.Windows.Data;

namespace WPFAppConverter.Core.ConverterNumber
{
    public class DecimalFormatConverter : IValueConverter
    {
        // Trimming to two zeros after the dot 
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null || value == DBNull.Value)
                return "N/A";

            return value is decimal decimalVal ? decimalVal.ToString("F2") : value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
            => throw new NotImplementedException();
    }
}