using InventoryManager.Models;
using InventoryManager.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

/*
 * Asynchronously looads all items from the BoughtItems table from the ItemsDB
 */
namespace InventoryManager.Commands {
    public class LoadBoughtItemsCommand : AsyncCommandBase {
        private readonly InventoryViewModel _viewModel;
        private readonly InventoryModel _inventory;

        public LoadBoughtItemsCommand(InventoryViewModel viewModel, InventoryModel inventory) {
            _viewModel = viewModel;
            _inventory = inventory;
        }

        public override async Task ExecuteAsync(object parameter) {
            
        
                IEnumerable<BoughtItemsModel> boughtItems = await _inventory.GetAllBoughtItems();
                _viewModel.UpdateItems(boughtItems);
          
        }

        
    }
}
