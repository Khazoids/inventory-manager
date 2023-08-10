using InventoryManager.Stores;
using InventoryManager.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManager.Services.NavigationServices
{
    public class ModalNavigationService<TViewModel>:INavigationService<TViewModel> where TViewModel : ViewModelBase
    {
        private readonly ModalNavigationStore _modalNavigationStore;
        private readonly Func<TViewModel> _createModalViewModel;

        public ModalNavigationService(ModalNavigationStore modalNavigationStore, Func<TViewModel> createModalViewModel)
        {
            _modalNavigationStore = modalNavigationStore;
            _createModalViewModel = createModalViewModel;
        }
    
        public void Navigate()
        {
            _modalNavigationStore.CurrentViewModel = _createModalViewModel();
        }
    }
}
