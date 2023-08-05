using InventoryManager.Models;
using InventoryManager.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* 
 * Asynchronously loads some items from the BoughtItems table from the ItemsDB.
 * How many items loaded are determined by the date range inputted by the user
 */
namespace InventoryManager.Commands
{
    public class LoadRecentlyBoughtItemsCommand:AsyncCommandBase
    {
        private readonly InventoryModel _inventory;
        private readonly RecentlyBoughtViewModel _viewModel;

        public LoadRecentlyBoughtItemsCommand(InventoryModel inventory, RecentlyBoughtViewModel viewModel)
        {
            _inventory = inventory;
            _viewModel = viewModel;
        }

        public override async Task ExecuteAsync(object parameter)   // TODO: Implement method that takes date input from the user and loads items between now and date range
        {
            IEnumerable<BoughtItemsModel> boughtItems = await _inventory.GetRecentlyBoughtItems();
            _viewModel.UpdateItems(boughtItems);
        }
    }
}
