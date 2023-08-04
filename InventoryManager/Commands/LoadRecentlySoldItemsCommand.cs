using InventoryManager.Models;
using InventoryManager.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManager.Commands
{
    public class LoadRecentlySoldItemsCommand:AsyncCommandBase
    {
        private readonly InventoryModel _inventory;
        private readonly RecentlySoldViewModel _viewModel;

        public LoadRecentlySoldItemsCommand(InventoryModel inventory, RecentlySoldViewModel viewModel)
        {
            _inventory = inventory;
            _viewModel = viewModel;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            IEnumerable<SoldItemsModel> soldItems = await _inventory.GetRecentlySoldItems();
            
        }
    }
}
