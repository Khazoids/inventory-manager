using InventoryManager.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManager.ViewModels {
    public class RecentlyBoughtViewModel : ViewModelBase {
        private readonly ObservableCollection<BoughtItemsViewModel> _boughtItems;

        public IEnumerable<BoughtItemsViewModel> BoughtItems => _boughtItems;
        public RecentlyBoughtViewModel() {
            _boughtItems = new ObservableCollection<BoughtItemsViewModel>();

            _boughtItems.Add(new BoughtItemsViewModel(new BoughtItemsModel(
                "Shipped", new ItemsModel("Figure Name", "Figure Type"), 4.50m, new DateOnly(2023, 01, 12), false)
                ));
                _boughtItems.Add(new BoughtItemsViewModel(new BoughtItemsModel(
                "Shipped", new ItemsModel("Figure Name", "Figure Type"), 4.50m, new DateOnly(2023, 01, 12), false)
                ));
            _boughtItems.Add(new BoughtItemsViewModel(new BoughtItemsModel(
                "Shipped", new ItemsModel("Figure Name", "Figure Type"), 4.50m, new DateOnly(2023, 01, 12), false)
                ));


        }
    }
}
