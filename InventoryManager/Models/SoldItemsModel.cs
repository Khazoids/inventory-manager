using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManager.Models {
    public class SoldItemsModel: DomainObject {
        
        public string ShippingStatus { get; }
        public ItemsModel Item { get; }
        public decimal Price { get; }
        public DateTime SaleDate { get; }

        public SoldItemsModel(string shippingStatus, ItemsModel item, decimal price, DateTime saleDate) {
            ShippingStatus = shippingStatus;
            Item = item;
            Price = price;
            SaleDate = saleDate;
        }
    }
}
