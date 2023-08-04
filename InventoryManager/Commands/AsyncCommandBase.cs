using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * This abstract class outlines the methods needed to execute asynchronous operations between the application and the SQL database
 */
namespace InventoryManager.Commands {
    public abstract class AsyncCommandBase:CommandBase {
        private bool _isExecuting;
        private bool IsExecuting {
            get { return _isExecuting; }
            set {
                _isExecuting = value;
                OnCanExecuteChanged();
            }
        }

        public override bool CanExecute(object parameter) {
            return !IsExecuting  && base.CanExecute(parameter);
        }

        public override async void Execute(object parameter) { 
            IsExecuting = true;

            try {
                await ExecuteAsync(parameter);
            } finally {

                IsExecuting = false;
            }
        }

        public abstract Task ExecuteAsync(object parameter);    
    }
}
