using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManager.Models {

    /// <summary>
    /// Represents the BoughtItems table data in memory
    /// </summary>
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

        /// <summary>
        /// Method returns data from the PurchasePrice column formatted to represent USD currency
        /// </summary>
        /// <returns></returns>
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
