using InventoryManager.Commands;
using InventoryManager.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace InventoryManager.ViewModels {
    public class InventoryViewModel : ViewModelBase {
        private readonly ObservableCollection<BoughtItemsViewModel> _boughtItems;
        private readonly InventoryModel _inventory;

        public IEnumerable<BoughtItemsViewModel> BoughtItems => _boughtItems;
        public ICommand LoadBoughtItemsCommand { get; }

        public InventoryViewModel(InventoryModel inventory)
        {
            _inventory = inventory;
            _boughtItems = new ObservableCollection<BoughtItemsViewModel>();

            LoadBoughtItemsCommand = new LoadBoughtItemsCommand(this, inventory);
        }

        public static InventoryViewModel LoadViewModel(InventoryModel inventory)
        {
            InventoryViewModel viewModel = new InventoryViewModel(inventory);

            viewModel.LoadBoughtItemsCommand.Execute(null);

            return viewModel;
        }
        public void UpdateItems(IEnumerable<BoughtItemsModel> boughtItems)
        {
            _boughtItems.Clear();

            foreach(BoughtItemsModel boughtItem in boughtItems)
            {
                BoughtItemsViewModel boughtItemsViewModel = new BoughtItemsViewModel(boughtItem);
                _boughtItems.Add(boughtItemsViewModel);
            }
        }
    }
}
