using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Labely
{
    class RelayCommand : ICommand
    {
        Action<object> ExecuteMethod;
        Func<object, bool> ConexecuteMethod;

        public RelayCommand(Func<object, bool> ConexecuteMethod, Action<object> ExecuteMethod)
        {
            this.ExecuteMethod = ExecuteMethod;
            this.ConexecuteMethod = ConexecuteMethod;
        }

       

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public event EventHandler CanExecuteChanged;

        public void Execute(object parameter)
        {
            ExecuteMethod(parameter);
        }
    }
}
