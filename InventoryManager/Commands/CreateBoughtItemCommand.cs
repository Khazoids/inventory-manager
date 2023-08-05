using InventoryManager.Models;
using InventoryManager.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

/*
 * Creates a BoughtItemDTO and asynchronously adds it to the database.
 * Navigation properties will also create a corresponding ItemsModel in the Items table.
 */
namespace InventoryManager.Commands {
    public class CreateBoughtItemCommand:AsyncCommandBase {
        private readonly InventoryModel _inventory;
        private readonly AddFormViewModel _addFormViewModel;
        public CreateBoughtItemCommand(InventoryModel inventory, AddFormViewModel addFormViewModel) {
            _inventory = inventory;
            _addFormViewModel = addFormViewModel;
        }
        public override async Task ExecuteAsync(object parameter) { // TODO: Validate whether a duplicate item exists before completing insertion
            BoughtItemsModel boughtItem = new BoughtItemsModel(
                _addFormViewModel.ShippingStatus,
                new ItemsModel(_addFormViewModel.ItemName, _addFormViewModel.ItemType),
                _addFormViewModel.Price,
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
