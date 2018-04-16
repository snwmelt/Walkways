using System;
using System.Windows.Input;

namespace Walkways.MVVM.View_Model
{
    /// <summary>
    /// An Implementation of The ICommand Interface That Supports Actions Following The Signiture A<T>(T Value).
    /// </summary>
    /// <typeparam name="T">Tupe Specifier.</typeparam>
    public class CommandRelay<T> : ICommand
    {
        #region Private Variables

        private readonly Action< T >    _Action;
        private readonly Predicate< T > _Predicate;

        #endregion

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="Action">Action to Be Executed.</param>
        /// <param name="Predicate">Predicate to Determine If The Action Parameter Can Be Executed.</param>
        public CommandRelay( Action< T > Action, Predicate< T > Predicate = null )
        {
            _Action    = Action;
            _Predicate = Predicate;
        }

        /// <summary>
        /// Action To Be Invoked.
        /// </summary>
        public Action< T > Action
        {
            get
            {
                return _Action;
            }
        }

        /// <summary>
        /// Invokes The Predicate In Order To Determine The Executable Status Of The Action,
        /// If No Predicate Is Provided The Result Is Always True.
        /// </summary>
        /// <param name="Parameter">Parameter For Predicate Invocation.</param>
        /// <returns>True If Action Is Currently Executable.</returns>
        public bool CanExecute( T Parameter )
        {
            if ( Predicate == null )
            {
                return true;
            }

            return Predicate( Parameter );
        }

        /// <summary>
        /// Invokes The Predicate In Order To Determine The Executable Status Of The Action,
        /// If No Predicate Is Provided The Result Is Always True.
        /// </summary>
        /// <param name="Parameter">Parameter For Predicate Invocation.</param>
        /// <returns>True If Action Is Currently Executable.</returns>
        public bool CanExecute( Object Parameter )
        {
            return CanExecute( ( T )Parameter );
        }

        /// <summary>
        /// Utalises COmmandManager To Poll For Changes That Might Affect Weather The Action Can Be Executed.
        /// </summary>
        public event EventHandler CanExecuteChanged
        {
            add
            {
                CommandManager.RequerySuggested += value;
            }

            remove
            {
                CommandManager.RequerySuggested -= value;
            }
        }

        /// <summary>
        /// Invokes The Action With A Given Parameter.
        /// </summary>
        /// <param name="Parameter">Parameter For Action Invocation.</param>
        public void Execute( T Parameter )
        {
            Action.Invoke( Parameter );
        }

        /// <summary>
        /// Invokes The Action With A Given Parameter.
        /// </summary>
        /// <param name="Parameter">Parameter For Action Invocation.</param>
        public void Execute( Object Parameter )
        {
            Execute( ( T )Parameter );
        }

        /// <summary>
        /// Predicate Used For Determining If The Action Can Be Currently Invoked.
        /// </summary>
        public Predicate<T> Predicate
        {
            get
            {
                return _Predicate;
            }
        }
    }
}
