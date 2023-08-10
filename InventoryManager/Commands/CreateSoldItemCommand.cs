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
    public class CreateSoldItemCommand:AsyncCommandBase
    {
        private readonly InventoryModel _inventory;
        private readonly AddFormViewModel _addFormViewModel;

        public CreateSoldItemCommand(InventoryModel inventory, AddFormViewModel addFormViewModel)
        {
            _inventory = inventory;
            _addFormViewModel = addFormViewModel;
        }
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
