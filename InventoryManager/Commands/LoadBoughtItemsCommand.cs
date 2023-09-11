using InventoryManager.Models;
using InventoryManager.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;


namespace InventoryManager.Commands {

    /// <summary>
    /// Asynchronously retrieves all data from the BoughtItems table in ItemsDB.
    /// </summary>
    public class LoadBoughtItemsCommand : AsyncCommandBase {

        private readonly InventoryViewModel _viewModel; // The view model that will eventually utilize the data.
        private readonly InventoryModel _inventory;

        /// <summary>
        /// Two constructor parameter
        /// </summary>
        /// <param name="viewModel">InventoryViewModel</param>
        /// <param name="inventory">InventoryModel</param>
        public LoadBoughtItemsCommand(InventoryViewModel viewModel, InventoryModel inventory) {
            _viewModel = viewModel;
            _inventory = inventory;
        }

        /// <summary>
        /// Retrieves all BoughtItems data.
        /// The passed in view model is then updated with the retrieved data.
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public override async Task ExecuteAsync(object parameter) {
                IEnumerable<BoughtItemsModel> boughtItems = await _inventory.GetAllBoughtItems();
                _viewModel.UpdateItems(boughtItems);
          
        }

        
    }
}
