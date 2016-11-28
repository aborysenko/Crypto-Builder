using System;
using System.Windows.Input;

namespace CryptoBuilder.UI.Helper
{
    public class RelayCommand : ICommand
    {
        private readonly Action<object> ExecuteAction;

        private readonly Predicate<object> CanExecuteAction;

        public RelayCommand(Action<object> execute)
            : this(execute, o => true)
        {
        }

        public RelayCommand(Action<object> action, Predicate<object> canExecute)
        {
            ExecuteAction = action;
            CanExecuteAction = canExecute;
        }

        public bool CanExecute(object parameter)
        {
            return CanExecuteAction(parameter);
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public void Execute(object parameter)
        {
            ExecuteAction(parameter);
        }
    }
}
