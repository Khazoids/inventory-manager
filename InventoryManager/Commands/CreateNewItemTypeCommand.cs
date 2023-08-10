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
    public class CreateNewItemTypeCommand:AsyncCommandBase
    {
        private readonly FormModel _formModel;
        private readonly FormOptionsViewModel _formOptionsViewModel;
        
        public CreateNewItemTypeCommand(FormModel formModel, FormOptionsViewModel formOptionsViewModel)
        {
            _formModel = formModel;
            _formOptionsViewModel = formOptionsViewModel;
        }
        public override async Task ExecuteAsync(object parameter)
        {
            FormOptionsModel formOptionsModel = new FormOptionsModel(_formOptionsViewModel.NewItemType, _formOptionsViewModel.NewItemStatus);

            try
            {
                await _formModel.CreateItemType(formOptionsModel);
                MessageBox.Show("Item Type created successfully", "Success",
                    MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception) 
            {
                MessageBox.Show("Item Type creation failed", "Error", 
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
