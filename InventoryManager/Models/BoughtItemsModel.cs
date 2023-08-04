using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManager.Models {
    public class BoughtItemsModel : DomainObject {
        // public int Id { get; set; }
        private readonly List<ItemsModel> _items;
        public string ShippingStatus { get; set; }
        public ItemsModel Item { get; set; }

        public decimal Price { get; set; }
        public DateTime PurchaseDate { get; set; }
        public bool IsListed { get; set; }

        public IEnumerable<ItemsModel> GetAllBoughtItems(string name) {
            return _items.Where(r => r.ItemName == name);
        }

        
        public BoughtItemsModel(string shippingStatus, ItemsModel item, decimal price, DateTime purchaseDate, bool isListed) {
            ShippingStatus = shippingStatus;
            Item = item;
            Price = price;
            PurchaseDate = purchaseDate;
            IsListed = isListed;
        }
    }
}
