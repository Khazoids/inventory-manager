using InventoryManager.Models;
using InventoryManager.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;


namespace InventoryManager.Commands {

    /// <summary>
    /// Asynchronously retrieves all data from the Items table in ItemsDB. 
    /// </summary>
    public class LoadAllItemsCommand:AsyncCommandBase {

        private readonly HistoryViewModel _viewModel;   // View model that will eventually utilize the data.
        private readonly InventoryModel _inventory;

        /// <summary>
        /// Two parameter constructor
        /// </summary>
        /// <param name="viewModel">HistoryViewModel</param>
        /// <param name="inventory"><InventoryModel/param>
        public LoadAllItemsCommand(HistoryViewModel viewModel, InventoryModel inventory)
        {
            _viewModel = viewModel;
            _inventory = inventory;
        }

        /// <summary>
        /// Retrieves all Items data by retrieving both BoughtItems and SoldItems and aggregates them together.
        /// The passed in view model is then updated with the retrieve data.
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public override async Task ExecuteAsync(object parameter) {

            IEnumerable<BoughtItemsModel> boughtItems = await _inventory.GetAllBoughtItems();
            IEnumerable<SoldItemsModel> soldItems = await _inventory.GetAllSoldItems();

            _viewModel.UpdateItems(boughtItems, soldItems);
        }
    }
}
