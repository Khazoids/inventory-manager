using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManager.Models {
    public class SoldItemsModel: DomainObject {
        // public int Id { get; set; }
        public string ShippingStatus { get; set; }
        public ItemsModel Item { get; set; }
        public decimal Price { get; set; }
        public DateOnly SaleDate { get; set; }

        public SoldItemsModel(string shippingStatus, ItemsModel item, decimal price, DateOnly saleDate) {
            ShippingStatus = shippingStatus;
            Item = item;
            Price = price;
            SaleDate = saleDate;
        }
    }
}
