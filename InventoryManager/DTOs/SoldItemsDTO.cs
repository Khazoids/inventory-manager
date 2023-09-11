using InventoryManager.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManager.DTOs
{   
    /// <summary>
    /// This class is the DTO representation of the SoldItemsModel
    /// </summary>
    public class SoldItemsDTO
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public ItemsDTO Item { get; set; }
        [Required]
        public string ShippingStatus { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public DateTime SaleDate { get; set; }

        public SoldItemsDTO() { }
        public SoldItemsDTO(ItemsDTO item, string shippingStatus, decimal price, DateTime saleDate)
        {
            Item = item;
            ShippingStatus = shippingStatus;
            Price = price;
            SaleDate = saleDate;
        }
    }
}
