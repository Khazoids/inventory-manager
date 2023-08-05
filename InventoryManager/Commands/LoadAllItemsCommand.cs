using InventoryManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * Asynchronously loads all items in the Items table from the ItemsDB
 */
namespace InventoryManager.Commands {
    public class LoadAllItemsCommand:AsyncCommandBase {
        
        public override Task ExecuteAsync(object parameter) {
            throw new NotImplementedException();
        }
    }
}
