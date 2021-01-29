using System;
using System.Windows.Input;

namespace MediaManager.WPF.Commands
{
    /// <summary>
    /// RelayCommand that can run a method with a generic typed parameter passed.
    /// </summary>
    /// <typeparam name="T">Type of the Parameterto be Passed</typeparam>
    public class RelayCommand<T> : ICommand
    {
        private readonly Action<T> _execute;
        private readonly Predicate<object> _canExecute;

        public RelayCommand(Action<T> execute) : this(execute, null) { }


        public RelayCommand(Action<T> execute, Predicate<Object> canExecute)
        {
            if (execute == null) throw new ArgumentNullException("execute");
            _execute = execute;
            _canExecute = canExecute;
        }

        public void Execute(object parameter)
        {
            _execute((T)parameter);
        }

        public bool CanExecute(object parameter)
        {
            return _canExecute == null ? true : _canExecute(parameter);
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }
    }
}
