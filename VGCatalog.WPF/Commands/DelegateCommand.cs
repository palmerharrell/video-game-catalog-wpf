using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace VGCatalog.WPF.Commands
{
    public class DelegateCommand : ICommand
    {
        public delegate void ParameterlessAction();
        public delegate bool ParameterlessPredicate();

        private readonly ParameterlessPredicate _canExecute;
        private readonly ParameterlessAction _execute;

        public event EventHandler CanExecuteChanged;

        public DelegateCommand(ParameterlessAction execute) : this(execute, null) { }

        public DelegateCommand(ParameterlessAction execute, ParameterlessPredicate canExecute)
        {
            _execute = execute;
            _canExecute = canExecute;
        }

        public bool CanExecute(object parameter)
        {
            if (_canExecute == null)
            {
                return true;
            }

            return _canExecute();
        }

        public void Execute(object parameter)
        {
            _execute();
        }

        public void RaiseCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}
