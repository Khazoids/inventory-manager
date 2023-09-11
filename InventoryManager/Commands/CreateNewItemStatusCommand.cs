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
    /// Creates a new Item Status that once created, can be selected from the Item Status
    /// drop down menu in the AddForm.
    /// </summary>
    public class CreateNewItemStatusCommand:AsyncCommandBase
    {
        private readonly FormModel _formModel;
        private readonly FormOptionsViewModel _formOptionsViewModel;    // e.g. Item Status, Item Type, Shipping Status

        /// <summary>
        /// Two parameter constructor
        /// </summary>
        /// <param name="formModel">FormModel</param>
        /// <param name="formOptionsViewModel">FormOptionsViewModel</param>
        public CreateNewItemStatusCommand(FormModel formModel, FormOptionsViewModel formOptionsViewModel)
        {
            _formModel = formModel;
            _formOptionsViewModel = formOptionsViewModel;
        }

        /// <summary>
        /// Extracts user-inputted data from the FormOptionsViewModel and modal to be passed into the InventoryModel
        /// for insertion into database.
        /// 
        /// If successful, a success message is displayed.
        /// 
        /// Otherwise, an error message is displayed.
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
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
