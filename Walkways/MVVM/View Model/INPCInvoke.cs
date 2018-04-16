using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Walkways.MVVM.View_Model
{
    /// <summary>
    /// A Class for use with the INotifyPropertyChanged property PropertyChanged.
    /// Raises PropertyChanged event arbitrarily, or on assinging new value to a referenced property from the calling class.
    /// </summary>
    public class INPCInvoke
    {
        #region Private Variables

        private INotifyPropertyChanged _Sender;

        #endregion

        /// <summary>
        /// INotifyPropertyChanged implementating class.
        /// </summary>
        /// <param name="Sender"></param>
        public INPCInvoke( INotifyPropertyChanged Sender )
        {
            _Sender = Sender;
        }

        /// <summary>
        /// Assigns Value To Referenced Property And Raises The INotifyPropertyChanged Property Changed Event.
        /// </summary>
        /// <typeparam name="T">Type Specifier.</typeparam>
        /// <param name="Handler">Reference To PropertyChanged PropertyChangedEventHandler Property to Invoke.</param>
        /// <param name="Property">Reference To Property To Be Assigned The Value.</param>
        /// <param name="Value">Value To Be Assigned To The Referenced Property.</param>
        /// <param name="PropertyName">Property Name/Title To Be Used When Raising Property Changed Event. If Omitted The Name Of The Calling Function Will Be Used.</param>
        public void AssignPropertyValue<T>( ref PropertyChangedEventHandler Handler, ref T Property, T Value, [CallerMemberName] String PropertyName = "" )
        {
            Property = Value;

            Handler?.Invoke( _Sender, new PropertyChangedEventArgs( PropertyName ) );
        }

        /// <summary>
        /// Raises The INotifyPropertyChanged Property Changed Event.
        /// If PropertyName is Omitted The Name Of The Calling Function Will Be Used.
        /// </summary>
        /// <param name="Handler">Reference To PropertyChanged PropertyChangedEventHandler Property to Invoke.</param>
        /// <param name="PropertyName">Infered / Explicit Property Name.</param>
        public void NotifyPropertyChanged( ref PropertyChangedEventHandler Handler, [ CallerMemberName ] String PropertyName = "" )
        {
            Handler?.Invoke( _Sender, new PropertyChangedEventArgs( PropertyName ) );
        }
    }
}
