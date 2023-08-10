using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManager.DTOs
{
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
