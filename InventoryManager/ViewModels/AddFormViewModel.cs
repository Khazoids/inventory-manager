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

        private string _category;
        public string Category { 
            get { return _category; }
            set {
                _category = value;
                OnPropertyChanged(nameof(Category));  
            }
        }

        private string _status;
        public string Status {
            get { return _status; }
            set {
                _status = value;
                OnPropertyChanged(nameof(Status));
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

        public ICommand AddStatus { get; }
        public ICommand AddCategory { get; }
        public ICommand Submit { get; }
        public ICommand Cancel { get; }

        public AddFormViewModel() { }
    }
}
