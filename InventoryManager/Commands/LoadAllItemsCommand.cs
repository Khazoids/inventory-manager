using InventoryManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManager.Commands {
    public class LoadAllItemsCommand:AsyncCommandBase {
        
        public override Task ExecuteAsync(object parameter) {
            throw new NotImplementedException();
        }
    }
}
