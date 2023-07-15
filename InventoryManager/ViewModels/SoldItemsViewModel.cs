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
        public string ItemName => _soldItems.Items.ItemName;
        public string ItemType => _soldItems.Items.ItemType;
        public decimal Price => _soldItems.Price;
        public DateOnly SaleDate => _soldItems.SaleDate;

        public SoldItemsViewModel(SoldItemsModel soldItems) {
            _soldItems = soldItems;

        }
    }
}
