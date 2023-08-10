using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManager.Models
{
    public class FormOptionsModel
    {
        public string ItemType { get; }
        public string ItemStatus { get; }

        public FormOptionsModel(string itemType, string itemStatus)
        {
            ItemType = itemType;
            ItemStatus = itemStatus;
        }
    }
}
