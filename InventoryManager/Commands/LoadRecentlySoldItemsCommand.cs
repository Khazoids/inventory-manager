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
    /// Asynchronously loads some items from the SoldItems table in ItemsDB.
    /// The number items is determined by the date range selected by the user in the view.
    /// </summary>
    public class LoadRecentlySoldItemsCommand:AsyncCommandBase
    {
        private readonly InventoryModel _inventory;
        private readonly RecentlySoldViewModel _viewModel; // The view model that will eventually utilize the data.

        /// <summary>
        /// Two parameter constructor
        /// </summary>
        /// <param name="inventory">InventoryModel</param>
        /// <param name="viewModel">RecentlySoldViewModel</param>
        public LoadRecentlySoldItemsCommand(InventoryModel inventory, RecentlySoldViewModel viewModel)
        {
            _inventory = inventory;
            _viewModel = viewModel;
        }


        /// <summary>
        /// Retrieves some data from the SoldItems table in ItemsDB.
        /// The view model is then updated with the retrieved data.
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public override async Task ExecuteAsync(object parameter) // TODO: implement method that takes date input from user and loads items between now and date range
        {
            IEnumerable<SoldItemsModel> soldItems = await _inventory.GetRecentlySoldItems();
            _viewModel.UpdateItems(soldItems);
        }
    }
}
