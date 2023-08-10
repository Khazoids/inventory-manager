using InventoryManager.Commands;
using InventoryManager.Models;
using InventoryManager.Services;
using InventoryManager.Services.NavigationServices;
using InventoryManager.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Navigation;

namespace InventoryManager.ViewModels {
    public class AddFormViewModel:ViewModelBase {
        private string _itemName;
        public string ItemName {
            get { return _itemName; }
            set {
                _itemName = value;
                OnPropertyChanged(nameof(ItemName));
            }
        }

        private string _itemType;
        public string ItemType { 
            get { return _itemType; }
            set {
                _itemType = value;
                OnPropertyChanged(nameof(ItemType));  
            }
        }

        private string _shippingStatus;
        public string ShippingStatus {
            get { return _shippingStatus; }
            set {
                _shippingStatus = value;
                OnPropertyChanged(nameof(ShippingStatus));
            }
        }

        private int _quantity;
        public int Quantity {
            get { return _quantity; }
            set {
                _quantity = value;
                OnPropertyChanged(nameof(Quantity));
            }
        }

      
        
        private string _price;
        public string Price {
            get { return _price; }
            set {
                _price = value;
                OnPropertyChanged(nameof(Price));
            }
        }

        private DateTime _purchaseDate = DateTime.Now;
        public DateTime PurchaseDate {
            get { return _purchaseDate; }
            set {
                _purchaseDate = value;
                OnPropertyChanged(nameof(PurchaseDate));
            }
        }

        private string _transactionType = "Purchase";
        public string TransactionType
        {
            get { return _transactionType; }
            set { 
            _transactionType = value;
            OnPropertyChanged(nameof(TransactionType));
            }
        }

        
        public ICommand NavigateAddItemTypeDialog { get; }
        public ICommand NavigateAddItemStatusDialog { get; }
        
        public ICommand SubmitCommand { get; }
        public ICommand CancelCommand { get; }
        
        public AddFormViewModel(InventoryModel inventory, INavigationService<AddItemTypeViewModel> addItemTypeModalNavigation, INavigationService<AddItemStatusViewModel> addItemStatusModalNavigation) {
            
            SubmitCommand = new CreateItemCommand(inventory, this, () => TransactionType );
            NavigateAddItemTypeDialog = new NavigateCommand<AddItemTypeViewModel>(addItemTypeModalNavigation);
            NavigateAddItemStatusDialog = new NavigateCommand<AddItemStatusViewModel>(addItemStatusModalNavigation);
            
        }
    }
}
