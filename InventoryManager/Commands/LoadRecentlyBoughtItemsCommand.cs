using InventoryManager.Models;
using InventoryManager.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public override async Task ExecuteAsync(object parameter)
        {
            IEnumerable<BoughtItemsModel> boughtItems = await _inventory.GetRecentlyBoughtItems();
            _viewModel.UpdateItems(boughtItems);
        }
    }
}
