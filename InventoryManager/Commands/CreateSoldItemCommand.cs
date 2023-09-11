using InventoryManager.Models;
using InventoryManager.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace InventoryManager.Commands
{
    /// <summary>
    /// Creates a SoldItemModel and inserts into in the Sold Items table in the database
    /// </summary>
    public class CreateSoldItemCommand:AsyncCommandBase
    {
        private readonly InventoryModel _inventory;
        private readonly AddFormViewModel _addFormViewModel;

        /// <summary>
        /// Two parameter constructor
        /// </summary>
        /// <param name="inventory">InventoryMode</param>
        /// <param name="addFormViewModel">AddFormViewModel</param>
        public CreateSoldItemCommand(InventoryModel inventory, AddFormViewModel addFormViewModel)
        {
            _inventory = inventory;
            _addFormViewModel = addFormViewModel;
        }

        /// <summary>
        /// Extracts user-inputted data from AddFormViewModel and creates a new SoldItemsModel.
        /// 
        /// If successful, the model is then passed to the InventoryModel to be inserted into the Database
        /// and a success message is displayed.
        /// 
        /// Otherwise, an error message is displayed.
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public override async Task ExecuteAsync(object parameter)
        {
            SoldItemsModel soldItem = new SoldItemsModel(
                _addFormViewModel.ShippingStatus,
                new ItemsModel(_addFormViewModel.ItemName, _addFormViewModel.ItemType),
                Decimal.Parse(_addFormViewModel.Price),
                _addFormViewModel.PurchaseDate
                );

            try
            {
                await _inventory.CreateSoldItem(soldItem);

                MessageBox.Show("Item created successfully", "Success",
                    MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception)
            {
                MessageBox.Show("Item creation failed", "Error",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
