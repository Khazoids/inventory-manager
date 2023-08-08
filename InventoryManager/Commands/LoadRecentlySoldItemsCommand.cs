using InventoryManager.Models;
using InventoryManager.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * Asynchronously loads some items from the SoldItems table in ItemsDB.
 * How many items loaded are determined by the date range inputted by the user
 */
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

        public override async Task ExecuteAsync(object parameter) // TODO: implement method that takes date input from user and loads items between now and date range
        {
            IEnumerable<SoldItemsModel> soldItems = await _inventory.GetRecentlySoldItems();
            _viewModel.UpdateItems(soldItems);
        }
    }
}
