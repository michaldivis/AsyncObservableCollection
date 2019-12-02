using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace Logic.Mvvm
{
    public class NiceCommand : ICommand
    {
        private readonly Func<object, bool> _canExecute;
        private readonly Action<object> _execute;

        public NiceCommand(Action<object> execute)
        {
            if (execute == null)
                throw new ArgumentNullException(nameof(execute));
            this._execute = execute;
        }

        public NiceCommand(Action execute)
            : this((Action<object>)(o => execute()))
        {
            if (execute == null)
                throw new ArgumentNullException(nameof(execute));
        }

        public NiceCommand(Action<object> execute, Func<object, bool> canExecute)
            : this(execute)
        {
            if (canExecute == null)
                throw new ArgumentNullException(nameof(canExecute));
            this._canExecute = canExecute;
        }

        public NiceCommand(Action execute, Func<bool> canExecute)
            : this((Action<object>)(o => execute()), (Func<object, bool>)(o => canExecute()))
        {
            if (execute == null)
                throw new ArgumentNullException(nameof(execute));
            if (canExecute == null)
                throw new ArgumentNullException(nameof(canExecute));
        }

        public bool CanExecute(object parameter)
        {
            if (this._canExecute != null)
                return this._canExecute(parameter);
            return true;
        }

        public event EventHandler CanExecuteChanged;

        public void Execute(object parameter)
        {
            this._execute(parameter);
        }

        public void ChangeCanExecute()
        {
            EventHandler canExecuteChanged = this.CanExecuteChanged;
            if (canExecuteChanged == null)
                return;
            canExecuteChanged((object)this, EventArgs.Empty);
        }
    }

}
