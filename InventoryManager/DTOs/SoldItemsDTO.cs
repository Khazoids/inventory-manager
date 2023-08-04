using InventoryManager.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManager.DTOs
{
    public class SoldItemsDTO
    {
        [Key]
        public Guid Id { get; set; }
        // public List<ItemsDTO> Items { get; set; }
        [Required]
        public ItemsDTO Item { get; set; }
        [Required]
        public string ShippingStatus { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public DateTime SaleDate { get; set; }
    }
}
