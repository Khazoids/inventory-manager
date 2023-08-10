using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManager.Models {
    public class BoughtItemsModel : DomainObject {
        private readonly List<ItemsModel> _items;
        public string ShippingStatus { get; }
        public ItemsModel Item { get;}

        public decimal PurchasePrice { get; }
        public DateTime PurchaseDate { get; }
        public bool IsListed { get; }

        public IEnumerable<ItemsModel> GetAllBoughtItems(string name) {
            return _items.Where(r => r.ItemName == name);
           
        }

        public string formatDecimal()
        {
            return String.Concat("-$", PurchasePrice);
        }


        public BoughtItemsModel(string shippingStatus, ItemsModel item, decimal purchasePrice, DateTime purchaseDate, bool isListed) {
            ShippingStatus = shippingStatus;
            Item = item;
            PurchasePrice = purchasePrice;
            PurchaseDate = purchaseDate;
            IsListed = isListed;
        }
    }
}
