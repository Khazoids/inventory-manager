using InventoryManager.Stores;
using InventoryManager.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * This class implements all the methods required for navigation in the application
 */
namespace InventoryManager.Services {
    public class NavigationService<TViewModel> : INavigationService<TViewModel>
        where TViewModel : ViewModelBase {

        private readonly NavigationStore _navigationStore; 
        private readonly Func<TViewModel> _createViewModel;

        public NavigationService(NavigationStore navigationStore, Func<TViewModel> createViewModel) {
            _navigationStore = navigationStore;
            _createViewModel = createViewModel;
        }

        public void Navigate() {
            _navigationStore.CurrentViewModel = _createViewModel();
        }
    }
}
