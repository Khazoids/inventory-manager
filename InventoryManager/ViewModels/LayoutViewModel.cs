using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManager.ViewModels
{
    public class LayoutViewModel : ViewModelBase
    {
        public NavigationBarViewModel NavigationBarViewModel { get; }
        public SearchBarViewModel SearchBarViewModel { get;  }
        public ViewModelBase ContentViewModel { get; }

        public LayoutViewModel(NavigationBarViewModel navigationBarViewModel, SearchBarViewModel searchBarViewModel, ViewModelBase contentViewModel) {
            NavigationBarViewModel = navigationBarViewModel;
            SearchBarViewModel = searchBarViewModel;
            ContentViewModel = contentViewModel;
        }

    }
}
