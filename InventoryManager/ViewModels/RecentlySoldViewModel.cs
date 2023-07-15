using InventoryManager.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManager.ViewModels
{
    public class RecentlySoldViewModel : ViewModelBase {
        private readonly ObservableCollection<SoldItemsViewModel> _soldItems;

        public IEnumerable<SoldItemsViewModel> SoldItems => _soldItems;
        public RecentlySoldViewModel() {
            _soldItems = new ObservableCollection<SoldItemsViewModel>();

            _soldItems.Add(new SoldItemsViewModel(new SoldItemsModel(
                "Shipped", new ItemsModel("Figure Name", "Figure Type"), 4.50m, new DateOnly(2023, 01, 12))
                ));
        }
    
        
    }
}
