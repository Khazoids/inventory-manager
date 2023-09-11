using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManager.DTOs
{
    /// <summary>
    /// This class is the DTO representation of the ItemTypeModel
    /// </summary>
    public class ItemTypeDTO
    {
        [Key]
        public string ItemType { get; set; }

        public ItemTypeDTO(string itemType)
        {
            ItemType = itemType.ToUpper();
        }
    }
}
