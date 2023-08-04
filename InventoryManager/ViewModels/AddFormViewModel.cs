using InventoryManager.Commands;
using InventoryManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

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

        private decimal _price;
        public decimal Price {
            get { return _price; }
            set {
                _price = value;
                OnPropertyChanged(nameof(Price));
            }
        }

        private DateTime _purchaseDate;
        public DateTime PurchaseDate {
            get { return _purchaseDate; }
            set {
                _purchaseDate = value;
                OnPropertyChanged(nameof(PurchaseDate));
            }
        }

        public ICommand AddStatusCommand { get; }
        public ICommand AddCategoryCommand { get; }
        public ICommand SubmitCommand { get; }
        public ICommand CancelCommand { get; }

        public AddFormViewModel(InventoryModel inventory) {
            SubmitCommand = new CreateBoughtItemCommand(inventory, this);
        }
    }
}
