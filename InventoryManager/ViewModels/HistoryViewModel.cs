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
    public class HistoryViewModel : ViewModelBase {
        private readonly ObservableCollection<BoughtItemsViewModel> _boughtItems;
        private readonly ObservableCollection<SoldItemsViewModel> _soldItems;
        private readonly InventoryModel _inventory;


        public IEnumerable<BoughtItemsViewModel> BoughtItems => _boughtItems;
        public IEnumerable<SoldItemsViewModel> SoldItems => _soldItems;
        public ICommand LoadAllItemsCommand { get; }

        public HistoryViewModel(InventoryModel inventory)
        {
            _inventory = inventory;

            _boughtItems = new ObservableCollection<BoughtItemsViewModel>();
            _soldItems = new ObservableCollection<SoldItemsViewModel>();

            LoadAllItemsCommand = new LoadAllItemsCommand()
        }
        public static HistoryViewModel LoadViewModel(InventoryModel inventory)
        {
            HistoryViewModel = new HistoryViewModel(inventory);

            ViewModelBase.LoadAllItemsCommand.Execute(null);

            return ViewModelBase;
        }
    }
}
