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
    /// Creates a BoughtItemsModel that will be passed to the persisting InventoryModel.
    /// Navigation properties will also create a corresponding ItemsModel in the Items table
    /// </summary>
    public class CreateBoughtItemCommand:AsyncCommandBase {

        private readonly InventoryModel _inventory;
        private readonly AddFormViewModel _addFormViewModel;

        /// <summary>
        /// Two parameter constructor
        /// </summary>
        /// <param name="inventory">InventoryModel</param>
        /// <param name="addFormViewModel">AddFormViewModel</param>
        public CreateBoughtItemCommand(InventoryModel inventory, AddFormViewModel addFormViewModel) {
            _inventory = inventory;
            _addFormViewModel = addFormViewModel;
        }

        /// <summary>
        /// ExecuteAsync will create a new BoughtItemsModel using the data passed in by the user in the AddForm and the AddFormViewModel.
        /// The model is then passed into the persisting InventoryModel where further commands will be executed to store it into the database.
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public override async Task ExecuteAsync(object parameter) { // TODO: Validate whether a duplicate item exists before completing insertion
            BoughtItemsModel boughtItem = new BoughtItemsModel(
                _addFormViewModel.ShippingStatus,
                new ItemsModel(_addFormViewModel.ItemName, _addFormViewModel.ItemType),
                Decimal.Parse(_addFormViewModel.Price),
                _addFormViewModel.PurchaseDate,
                false);

            try {
                await _inventory.CreateBoughtItem(boughtItem);

                MessageBox.Show("Item created successfully", "Success",
                    MessageBoxButton.OK, MessageBoxImage.Information);
            } catch (Exception) {
                MessageBox.Show("Item creation failed", "Error",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
