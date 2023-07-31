using InventoryManager.Services;
using InventoryManager.Stores;
using InventoryManager.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManager.Commands {
    public class NavigateCommand<TViewModel> : CommandBase 
        where TViewModel : ViewModelBase {

       
        private readonly INavigationService<TViewModel> _navigationService;

        public NavigateCommand(INavigationService<TViewModel> navigationService) {
            _navigationService = navigationService;
        }

        public override void Execute(object parameter) {
            _navigationService.Navigate();
        }
    }
}
