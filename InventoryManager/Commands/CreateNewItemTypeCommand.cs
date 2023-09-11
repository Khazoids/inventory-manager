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
    /// Creates a new Item Type that, once created, can be selected from the Item Type
    /// drop down menu in the Addform.
    /// </summary>
    public class CreateNewItemTypeCommand:AsyncCommandBase
    {
        private readonly FormModel _formModel;
        private readonly FormOptionsViewModel _formOptionsViewModel; // e.g. Item Type, Item Status, Shipping Status
        
        /// <summary>
        /// Two Parameter constructor
        /// </summary>
        /// <param name="formModel">FormModel</param>
        /// <param name="formOptionsViewModel">FormOptionsViewModel</param>
        public CreateNewItemTypeCommand(FormModel formModel, FormOptionsViewModel formOptionsViewModel)
        {
            _formModel = formModel;
            _formOptionsViewModel = formOptionsViewModel;
        }

        /// <summary>
        /// Extracts data from the FormOptionsViewModel and creates a FormOptionsModel object.
        /// The model is then inserted into the database.
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
