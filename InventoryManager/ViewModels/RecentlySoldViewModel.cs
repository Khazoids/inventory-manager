using InventoryManager.Commands;
using InventoryManager.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace InventoryManager.ViewModels
{
    public class RecentlySoldViewModel : ViewModelBase {
        private readonly ObservableCollection<SoldItemsViewModel> _soldItems;
        private readonly InventoryModel _inventory;
        public IEnumerable<SoldItemsViewModel> SoldItems => _soldItems;
        public ICommand LoadRecentlySoldItemsCommand { get; }

        public RecentlySoldViewModel(InventoryModel inventory)
        {
            _inventory = inventory;
            _soldItems = new ObservableCollection<SoldItemsViewModel>();
            LoadRecentlySoldItemsCommand = new LoadRecentlySoldItemsCommand(inventory, this);
        }

        public static RecentlySoldViewModel LoadviewModel(InventoryModel inventory)
        {
            RecentlySoldViewModel viewModel = new RecentlySoldViewModel(inventory);

            return viewModel;
        }

        public void UpdateItems(IEnumerable<SoldItemsModel> soldItems)
        {
            _soldItems.Clear();

            foreach(SoldItemsModel soldItem in soldItems)
            {
                SoldItemsViewModel soldItemsViewModel = new SoldItemsViewModel(soldItem);

                _soldItems.Add(soldItemsViewModel);
            }
        }
    }
}
