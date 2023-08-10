using InventoryManager.Commands;
using InventoryManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace InventoryManager.ViewModels
{
    public class FormOptionsViewModel : ViewModelBase
    {
        private string _newItemType;
        public string NewItemType
        {
            get { return _newItemType; }
            set { 
                _newItemType = value;
                OnPropertyChanged(nameof(NewItemType));
            }
        }

        private string _newItemStatus;
        public string NewItemStatus
        {
            get { return _newItemStatus; }
            set
            {
                _newItemStatus = value;
                OnPropertyChanged(nameof(NewItemStatus));
            }
        }

        public ICommand CreateNewItemType;
        public ICommand CreateNewItemStatus;

        public FormOptionsViewModel(FormModel formModel)
        {
            CreateNewItemType = new CreateNewItemTypeCommand(formModel, this);
            CreateNewItemStatus = new CreateNewItemStatusCommand(formModel, this);
        }
    }
}
