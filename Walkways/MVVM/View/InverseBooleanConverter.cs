using System;
using System.Globalization;
using System.Windows.Data;

namespace Walkways.MVVM.View
{
    /// <summary>
    /// Inverts the value of a Bool(ean).
    /// </summary>
    public class InverseBooleanConverter : IValueConverter
    {
        public object Convert( object value, Type targetType, object parameter, CultureInfo culture )
        {
            if ( !( value is Boolean ) )
            {
                throw new InvalidOperationException( "Target Type Must be a Boolean." );
            }

            return !( Boolean )value;
        }

        public object ConvertBack( object value, Type targetType, object parameter, CultureInfo culture )
        {
            throw new NotImplementedException( );
        }
    }
}
