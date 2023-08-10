using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManager.Models
{
    public class ItemTypeModel
    {
        public string ItemType { get; }

        public ItemTypeModel(string itemType)
        {
            ItemType = itemType;
        }
    }
}
