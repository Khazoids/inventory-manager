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
    /// <summary>
    /// This class is the DTO representation of the ItemsModel
    /// </summary>
    public class ItemsDTO
    {
        
        [Key]
        public Guid Id { get; set; }
        [Required]
        public string ItemName { get; set; }
        [Required]
        public string ItemType { get; set; }

        public ItemsDTO(string itemName, string itemType) {
            ItemName = itemName; 
            ItemType = itemType;
      
        }

        
    }
}
