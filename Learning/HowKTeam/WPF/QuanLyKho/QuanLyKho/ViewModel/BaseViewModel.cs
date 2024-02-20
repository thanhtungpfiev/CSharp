using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace QuanLyKho.ViewModel
{
    /// <summary>
    /// Base view model class that implements the INotifyPropertyChanged interface.
    /// </summary>
    internal class BaseViewModel : INotifyPropertyChanged
    {
        /// <summary>
        /// Event that is raised when a property value changes.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Raises the PropertyChanged event for the specified property.
        /// </summary>
        /// <param name="propertyName">The name of the property that changed.</param>
        protected virtual void onPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    /// <summary>
    /// A generic implementation of the ICommand interface for relay commands.
    /// </summary>
    /// <typeparam name="T">The type of the command parameter.</typeparam>
    class RelayCommmand<T> : ICommand
    {
        private readonly Predicate<T> _canExecute;
        private readonly Action<T> _execute;

        /// <summary>
        /// Initializes a new instance of the RelayCommmand class.
        /// </summary>
        /// <param name="canExecute">The predicate that determines whether the command can execute.</param>
        /// <param name="execute">The action to execute when the command is executed.</param>
        public RelayCommmand(Predicate<T> canExecute, Action<T> execute)
        {
            if (execute == null)
            {
                throw new ArgumentNullException("execute");
            }
            _canExecute = canExecute;
            _execute = execute;
        }

        /// <summary>
        /// Event that is raised when the ability of the command to execute changes.
        /// </summary>
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        /// <summary>
        /// Determines whether the command can execute with the specified parameter.
        /// </summary>
        /// <param name="parameter">The parameter to check for command execution.</param>
        /// <returns>True if the command can execute, otherwise false.</returns>
        public bool CanExecute(object parameter)
        {
            try
            {
                return _canExecute == null ? true : _canExecute((T)parameter);
            }
            catch
            {
                return true;
            }
        }

        /// <summary>
        /// Executes the command with the specified parameter.
        /// </summary>
        /// <param name="parameter">The parameter to execute the command with.</param>
        public void Execute(object parameter)
        {
            _execute((T)parameter);
        }
    }
}
