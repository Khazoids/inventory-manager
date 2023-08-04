using InventoryManager.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManager.DTOs
{
    public class BoughtItemsDTO
    {
        
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string ShippingStatus { get; set; }

        [Required]
        public ItemsDTO Item { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public DateTime PurchaseDate { get; set; }
        [Required]
        public bool IsListed { get; set; }

        public BoughtItemsDTO() {

        }
        public BoughtItemsDTO(string shippingStatus, ItemsDTO item, decimal price, DateTime purchaseDate, bool isListed) {
            
            ShippingStatus = shippingStatus;
            Item = item;
            Price = price;
            PurchaseDate = purchaseDate;
            IsListed = isListed;
        }

    }
}
