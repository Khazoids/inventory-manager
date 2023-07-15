using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManager.Models {
    public class SoldItemsModel: DomainObject {
        // public int Id { get; set; }
        public string ShippingStatus { get; set; }
        public ItemsModel Items { get; set; }
        public decimal Price { get; set; }
        public DateOnly SaleDate { get; set; }

        public SoldItemsModel(string shippingStatus, ItemsModel items, decimal price, DateOnly saleDate) {
            ShippingStatus = shippingStatus;
            Items = items;
            Price = price;
            SaleDate = saleDate;
        }
    }
}
