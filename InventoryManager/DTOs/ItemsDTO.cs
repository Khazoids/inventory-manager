using InventoryManager.Models;
using InventoryManager.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManager.DTOs
{
    public class ItemsDTO
    {
        
        [Key]
        public Guid Id { get; set; }
        public string ItemName { get; set; }
        public string ItemType { get; set; }

        public ItemsDTO(string itemName, string itemType) {
            ItemName = itemName; 
            ItemType = itemType;
      
        }

        
    }
}
