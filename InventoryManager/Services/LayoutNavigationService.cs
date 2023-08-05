using InventoryManager.Stores;
using InventoryManager.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * This class represents the code-behind for our layout view.
 * The layout aims to remove duplicate code wby encapsulating parts of our views that remain constant throughout the app into this view model.
 */
namespace InventoryManager.Services
{
    public class LayoutNavigationService<TViewModel> : INavigationService<TViewModel> where TViewModel : ViewModelBase
    {
        private readonly NavigationStore _navigationStore;
        private readonly Func<TViewModel> _createViewModel;
        private readonly Func<NavigationBarViewModel> _createNavigationBarViewModel;
        private readonly Func<SearchBarViewModel> _createSearchBarViewModel;

        public LayoutNavigationService(NavigationStore navigationStore, 
            Func<TViewModel> createViewModel, 
            Func<NavigationBarViewModel> createNavigationBarViewModel, 
            Func<SearchBarViewModel> createSearchBarViewModel)
        {
            _navigationStore = navigationStore;
            _createViewModel = createViewModel;
            _createNavigationBarViewModel = createNavigationBarViewModel;
            _createSearchBarViewModel = createSearchBarViewModel;
        }

        public void Navigate()
        {
            _navigationStore.CurrentViewModel = new LayoutViewModel(_createNavigationBarViewModel(), _createSearchBarViewModel(), _createViewModel());
        }
    }
}
