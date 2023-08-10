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
    public class CreateNewItemStatusCommand:AsyncCommandBase
    {
        private readonly FormModel _formModel;
        private readonly FormOptionsViewModel _formOptionsViewModel;

        public CreateNewItemStatusCommand(FormModel formModel, FormOptionsViewModel formOptionsViewModel)
        {
            _formModel = formModel;
            _formOptionsViewModel = formOptionsViewModel;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            FormOptionsModel formOptionsModel = new FormOptionsModel(_formOptionsViewModel.NewItemType, _formOptionsViewModel.NewItemStatus);

            try
            {
                await _formModel.CreateItemStatus(formOptionsModel);

                MessageBox.Show("Item Status created successfully", "Success",
                    MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception) 
            {
                MessageBox.Show("Item Status creation failed", "Error",
                    MessageBoxButton.OK, MessageBoxImage.Error);            
            }
        }
    }
}
