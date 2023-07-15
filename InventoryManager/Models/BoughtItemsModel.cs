using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManager.Models {
    public class BoughtItemsModel : DomainObject {
        // public int Id { get; set; }
        public string ShippingStatus { get; set; }
        public ItemsModel Items { get; set; }

        public decimal Price { get; set; }
        public DateOnly PurchaseDate { get; set; }
        public bool IsListed { get; set; }

        public BoughtItemsModel(string shippingStatus, ItemsModel items, decimal price, DateOnly purchaseDate, bool isListed) {
            ShippingStatus = shippingStatus;
            Items = items;
            Price = price;
            PurchaseDate = purchaseDate;
            IsListed = isListed;
        }
    }
}
