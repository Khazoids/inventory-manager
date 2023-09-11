using InventoryManager.Models;
using InventoryManager.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManager.Commands
{
    /// <summary>
    /// Asynchronously loads some items from the BoughtItems table from ItemsDB.
    /// The number of items loaded is determined by the date range inputted by the user.
    /// </summary>
    public class LoadRecentlyBoughtItemsCommand:AsyncCommandBase
    {
        private readonly InventoryModel _inventory;
        private readonly RecentlyBoughtViewModel _viewModel;    // The view model that eventually utilize the data.

        /// <summary>
        /// Two parameter constructor
        /// </summary>
        /// <param name="inventory"></param>
        /// <param name="viewModel"></param>
        public LoadRecentlyBoughtItemsCommand(InventoryModel inventory, RecentlyBoughtViewModel viewModel)
        {
            _inventory = inventory;
            _viewModel = viewModel;
        }

        /// <summary>
        /// Retrieves some data from the BoughtItems table.
        /// The view model is updated with the retrived data.
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public override async Task ExecuteAsync(object parameter)   // TODO: Implement method that takes date input from the user and loads items between now and date range
        {
            IEnumerable<BoughtItemsModel> boughtItems = await _inventory.GetRecentlyBoughtItems();
            _viewModel.UpdateItems(boughtItems);
        }
    }
}
