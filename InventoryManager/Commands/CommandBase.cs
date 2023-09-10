using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;


namespace InventoryManager.Commands {

    /// <summary>
    ///  Abstract class that outlines what a command should do in this application.
    ///  Commands are then implemented in the view models of the corresponding view.
    /// </summary>
    public abstract class CommandBase:ICommand {
        public event EventHandler CanExecuteChanged;

        public virtual bool CanExecute(object parameter) {
            return true;
        }

        public abstract void Execute(object parameter);
       
        protected void OnCanExecuteChanged() {
            CanExecuteChanged?.Invoke(this, new EventArgs());
        }
        
    }
}
