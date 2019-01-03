using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace Walkways.MVVM.View
{
    /// <summary>
    /// Parses n+ System.Boolean objects translating the agrigate of their values into a System.Windows.Visibility object.
    /// </summary>
    public class MultiValueBooleanToVisibilityConverter : IMultiValueConverter
    {
        /// <summary>
        /// Returns a System.Windows.Visibility Object Given The Values Of N+ System.Boolean Objects.
        /// </summary>
        /// <param name="values">An Array Containing System.Boolean Objects.</param>
        /// <param name="targetType">System.Windows.Data.IMultiValueConverter Target System.Type.</param>
        /// <param name="parameter">System.Windows.Data.IMultiValueConverter Source System.Object.</param>
        /// <param name="culture">System.Windows.Data.IMultiValueConverter Source System.Globalization.CultureInfo.</param>
        /// <returns>System.Windows.Visibility Result.</returns>
        public object Convert( object[] values, Type targetType = null, object parameter = null, CultureInfo culture = null )
        {
            foreach ( object value in values )
            {
                if ( !( value is Boolean ) )
                {
                    throw new InvalidOperationException( "Target Type Must be a Boolean." );
                }

                if ( !( Boolean )value )
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
