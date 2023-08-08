using InventoryManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManager.ViewModels
{
    public class SoldItemsViewModel
    {
        private readonly SoldItemsModel _soldItems;

        public string ShippingStatus => _soldItems.ShippingStatus;
        public string ItemName => _soldItems.Item.ItemName;
        public string ItemType => _soldItems.Item.ItemType;
        public string SalePrice => _soldItems.formatDecimal();
        public string SaleDate => _soldItems.SaleDate.ToString("d");

        public SoldItemsViewModel(SoldItemsModel soldItems) {
            _soldItems = soldItems;

        }
    }
}
