using InventoryManager.Models;
using InventoryManager.ViewModels;
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
        private readonly HistoryViewModel _viewModel;
        private readonly InventoryModel _inventory;

        public LoadAllItemsCommand(HistoryViewModel viewModel, InventoryModel inventory)
        {
            _viewModel = viewModel;
            _inventory = inventory;
        }

        public override async Task ExecuteAsync(object parameter) {
            
        }
    }
}
