using InventoryManager.Commands;
using InventoryManager.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace InventoryManager.ViewModels {
    public class NavigationBarViewModel : ViewModelBase {
        public ICommand NavigateHomeCommand { get; }
        public ICommand NavigateInventoryCommand { get; }
        public ICommand NavigateHistoryCommand { get; }
        public ICommand NavigateExpensesCommand { get; }

        public NavigationBarViewModel(NavigationStore navigationStore) {
            NavigateHomeCommand = new NavigateCommand(navigationStore, )  
        }
    }
}
