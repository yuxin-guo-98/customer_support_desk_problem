using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace customersupport.Commands
{
    public class AddCustomerCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;
        private Action DoWork;
        public AddCustomerCommand(Action work)
        {
            DoWork = work;
        }
        public bool CanExecute(object parameter)
        {
            return true;
        }
        public void Execute(object parameter)
        {
           DoWork();
        }
    }
}
