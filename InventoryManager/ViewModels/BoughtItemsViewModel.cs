using InventoryManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManager.ViewModels {
    public class BoughtItemsViewModel : ViewModelBase {

        private readonly BoughtItemsModel _boughtItems;
        public string ShippingStatus => _boughtItems.ShippingStatus;
        public string ItemName => _boughtItems.Item.ItemName;
        public string ItemType => _boughtItems.Item.ItemType;
        public decimal Price => _boughtItems.Price;
        public string PurchaseDate => _boughtItems.PurchaseDate.ToString("d");
        public bool IsListed => _boughtItems.IsListed;

        public BoughtItemsViewModel(BoughtItemsModel boughtItems) {
            _boughtItems = boughtItems;
        }

    
    }
}
