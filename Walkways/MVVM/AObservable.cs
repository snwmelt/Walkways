using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Walkways.MVVM
{
    /// <summary>
    /// An Abstract Class For Use In Creating Observable Objects.
    /// </summary>
    public abstract class AObservable : INotifyPropertyChanged
    {
        /// <summary>
        /// Assigns Value To Referenced Property And Raises The INotifyPropertyChanged Property Changed Event.
        /// </summary>
        /// <typeparam name="T">Type Specifier.</typeparam>
        /// <param name="Property">Reference To Property To Be Assigned The Value.</param>
        /// <param name="PropertyName">Property Name/Title To Be Used When Raising Property Changed Event.</param>
        /// <param name="Value">Value To Be Assigned To The Referenced Property.</param>
        protected void AssignPropertyValue<T>( ref T Property, T Value, [CallerMemberName] String PropertyName = "" )
        {
            Property = Value;

            PropertyChanged?.Invoke( this, new PropertyChangedEventArgs( PropertyName ) );
        }

        /// <summary>
        /// Raises The INotifyPropertyChanged Property Changed Event.
        /// If No Parameter Is Passed The Name Of The Calling Function Will Be Infered And Used As The Value Of PropertyName.
        /// </summary>
        /// <param name="PropertyName">Infered / Explicit Property Name.</param>
        protected void NotifyPropertyChanged( [ CallerMemberName ] String PropertyName = "" )
        {
            PropertyChanged?.Invoke( this, new PropertyChangedEventArgs( PropertyName ) );
        }

        /// <summary>
        /// INotifyPropertyChanged Property Changed Event Handler.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
