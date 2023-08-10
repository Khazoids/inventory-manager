using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManager.Models {
    public class SoldItemsModel: DomainObject {
        
        public string ShippingStatus { get; }
        public ItemsModel Item { get; }
        public decimal SalePrice { get; }
        public DateTime SaleDate { get; }

        public string formatDecimal()
        {
            return String.Concat("+$", SalePrice);
        }
        public SoldItemsModel(string shippingStatus, ItemsModel item, decimal salePrice, DateTime saleDate) {
            ShippingStatus = shippingStatus;
            Item = item;
            SalePrice = salePrice;
            SaleDate = saleDate;
        }
    }
}
