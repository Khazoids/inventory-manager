using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManager.ViewModels {
    public class HomeViewModel : ViewModelBase {
        private readonly RecentlyBoughtViewModel _boughtItems;
        private readonly RecentlySoldViewModel _soldItems;

        public IEnumerable<BoughtItemsViewModel> BoughtItems => _boughtItems.BoughtItems;
        public IEnumerable<SoldItemsViewModel> SoldItems => _soldItems.SoldItems;
        public HomeViewModel(RecentlyBoughtViewModel BoughtItems, RecentlySoldViewModel SoldItems) {
            _boughtItems = BoughtItems;
            _soldItems = SoldItems;
        }
    }
}
