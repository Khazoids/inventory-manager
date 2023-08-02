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
        public string ItemName { get; set; }
        public string ItemType { get; set; }
        public string ShippingStatus { get; set; }
        public decimal Price { get; set; }
        public DateOnly SaleDate { get; set; }
    }
}
