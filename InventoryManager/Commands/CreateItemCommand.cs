using InventoryManager.Models;
using InventoryManager.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace InventoryManager.Commands {
    public class CreateItemCommand:AsyncCommandBase {
        private readonly InventoryModel _inventory;
        private readonly AddFormViewModel _addFormViewModel;
        Func<string> _getTransactionType;
        public CreateItemCommand(InventoryModel inventory, AddFormViewModel addFormViewModel, Func<string> getTransactionType)
        {
            _getTransactionType = getTransactionType;
            _inventory = inventory;
            _addFormViewModel = addFormViewModel;
        }

    

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
