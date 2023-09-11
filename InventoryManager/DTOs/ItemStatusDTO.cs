using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManager.DTOs
{
    /// <summary>
    /// This class is the DTO representation of the ItemStatusModel
    /// </summary>
    public class ItemStatusDTO
    {
        [Key]
        public string ItemStatus { get; set; }

        public ItemStatusDTO(string itemStatus)
        {
            ItemStatus = itemStatus.ToUpper();
        }
    }
}
