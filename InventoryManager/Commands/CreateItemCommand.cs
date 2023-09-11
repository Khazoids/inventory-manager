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
    /// CreateItemsCommand will create a new item and pass the information to the right method to map it to its corresopnding table.
    /// The method takes a three parameter constructor. Once called, the method will extract information from the AddFormViewModel
    /// and pass it, along with the InventoryMode, to another Create command depending on whether "Purchase" or "Sale" is checked by
    /// the user in the AddForm.
    /// </summary>
    public class CreateItemCommand:AsyncCommandBase {

        private readonly InventoryModel _inventory;
        private readonly AddFormViewModel _addFormViewModel;
        Func<string> _getTransactionType;

        /// <summary>
        /// Three parameter constructor
        /// </summary>
        /// <param name="inventory">InventoryModel</param>
        /// <param name="addFormViewModel">AddFormViewModel</param>
        /// <param name="getTransactionType">Method Factory; retrieves the "Transaction Type" value from form (e.g "Purchase", "Sale")</param>
        public CreateItemCommand(InventoryModel inventory, AddFormViewModel addFormViewModel, Func<string> getTransactionType)
        {
            _getTransactionType = getTransactionType;
            _inventory = inventory;
            _addFormViewModel = addFormViewModel;
        }

    
        /// <summary>
        /// Extracts data from the AddFormViewModel and will either call CreateBoughtItemCommand or CreateSoldItemCommand
        /// depending on what the user checked in the AddForm.
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public override async Task ExecuteAsync(object parameter)
        {
            if (_getTransactionType().Equals("Purchase"))
            {
                await new CreateBoughtItemCommand(_inventory, _addFormViewModel).ExecuteAsync(null);
            } 
            else if (_getTransactionType().Equals("Sale"))
            {
                await new CreateSoldItemCommand(_inventory, _addFormViewModel).ExecuteAsync(null);
            }
        }
    }
}
