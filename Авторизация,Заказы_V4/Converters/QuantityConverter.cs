using System;
using System.Globalization;
using System.Windows.Data;

namespace TestApp.Converters {
    public class QuantityConverter : IValueConverter {

        //из источника в форму
        public object Convert ( object value, Type targetType, object parameter, CultureInfo culture ) {
            return value;

        }
        //из формы в источник
        public object ConvertBack ( object value, Type targetType, object parameter, CultureInfo culture ) {


            if ( value.ToString ( ) == "" || int.TryParse ( value.ToString ( ), out int v ) ) {
                return value;
            }
            else {
                return 1;
            }
        }
    }
}
