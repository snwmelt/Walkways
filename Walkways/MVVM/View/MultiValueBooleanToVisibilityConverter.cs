using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace Walkways.MVVM.View
{
    /// <summary>
    /// Parses n+ Bool(ean)s translating the agrigate of their values into a System.Windows.Visibility object.
    /// </summary>
    public class MultiValueBooleanToVisibilityConverter : IMultiValueConverter
    {
        public object Convert( object[] values, Type targetType, object parameter, CultureInfo culture )
        {
            foreach ( object v in values )
            {
                if ( ( v is bool ) && !( Boolean )v )
                {
                    return Visibility.Collapsed;
                }
            }

            return Visibility.Visible;
        }

        public object[] ConvertBack( object value, Type[] targetTypes, object parameter, CultureInfo culture )
        {
            throw new NotImplementedException( );
        }
    }
}
