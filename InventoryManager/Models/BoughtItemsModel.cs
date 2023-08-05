using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManager.Models {
    public class BoughtItemsModel : DomainObject {
        private readonly List<ItemsModel> _items;
        public string ShippingStatus { get; }
        public ItemsModel Item { get;}

        public decimal Price { get; }
        public DateTime PurchaseDate { get; }
        public bool IsListed { get; }

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
