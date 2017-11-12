#region System Usings
using System;
using System.Diagnostics;
using System.Windows.Input;
#endregion System Usings

namespace Company.TestApp.ViewModels
{
    /// <summary>
    /// A basic command that runs an Action
    /// </summary>
    /// 
    public class RelayCommand : ICommand
    {
        #region Fields
        /// <summary>
        /// The action to run
        /// </summary>
        readonly Action<object> _execute;
        readonly Predicate<object> _canExecute;

        #endregion Fields

        #region Constructors 

        /// <summary>
        /// RelayCommand Constructor with 1 params 
        /// </summary>
        /// <param name="execute"></param>
        public RelayCommand(Action<object> execute)
        : this(execute, null)
        {
        }
        /// <summary>
        /// RelayCommand Constructor with 2 params
        /// </summary>
        /// <param name="execute"></param>
        /// <param name="canExecute"></param>
        public RelayCommand(Action<object> execute, Predicate<object> canExecute)
        {
            if (execute == null)
                throw new ArgumentNullException("execute");

            _execute = execute;
            _canExecute = canExecute;
        }
        #endregion  Constructors

        #region ICommand Members
        /// <summary>
        /// A relay command can always execute
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        [DebuggerStepThrough]
        public bool CanExecute(object parameter)
        {
            return _canExecute == null ? true : _canExecute(parameter);
        }
        /// <summary>
        /// CanExecuteChanged event
        /// </summary>
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }
        /// <summary>
        /// Executes the commands Action
        /// </summary>
        /// <param name="parameter"></param>
        public void Execute(object parameter)
        {
            _execute(parameter);
        }

        #endregion  ICommand Members
    }
}
