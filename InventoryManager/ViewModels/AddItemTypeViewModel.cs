using InventoryManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace InventoryManager.ViewModels
{
    public class AddItemTypeViewModel : ViewModelBase
    {
        private readonly InventoryModel _inventory;
        private string _newItemType;
        public string NewItemType
        {
            get { return _newItemType; }
            set 
            { 
                _newItemType = value;
                OnPropertyChanged(nameof(NewItemType));
            }
        }

        public ICommand Submit;
        public ICommand Cancel;


        public AddItemTypeViewModel()
        {
            
        }
    }
}
