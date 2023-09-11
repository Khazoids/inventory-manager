using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManager.Models
{   
    /// <summary>
    /// This class stores data for ItemType and ItemStatus options that appear in the drop-down menus
    /// inside the Add form.
    /// </summary>
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
