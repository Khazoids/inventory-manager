using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManager.Models {
    public class ItemsModel : DomainObject {
        // public int Id { get; set; }
        public string ItemName { get; set; }
        public string ItemType { get; set; }
    }
}
