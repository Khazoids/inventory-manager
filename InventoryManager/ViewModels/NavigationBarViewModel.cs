using InventoryManager.Commands;
using InventoryManager.Services;
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

        public NavigationBarViewModel(
            INavigationService<HomeViewModel> homeNavigation,
            INavigationService<InventoryViewModel> inventoryNavigation,
            INavigationService<HistoryViewModel> historyNavigation,
            INavigationService<ExpensesViewModel> expensesNavigation
            ) {

            NavigateHomeCommand = new NavigateCommand<HomeViewModel>(homeNavigation);
            NavigateInventoryCommand = new NavigateCommand<InventoryViewModel>(inventoryNavigation);
            NavigateHistoryCommand = new NavigateCommand<HistoryViewModel>(historyNavigation);
            NavigateExpensesCommand = new NavigateCommand<ExpensesViewModel>(expensesNavigation);
            
        }
    }
}
