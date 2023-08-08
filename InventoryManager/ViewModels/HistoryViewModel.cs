using InventoryManager.Commands;
using InventoryManager.Converters;
using InventoryManager.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Input;

namespace InventoryManager.ViewModels
{
    public class HistoryViewModel:ViewModelBase
    {
        private readonly CompositeCollection _itemsCollection;
        private readonly ObservableCollection<BoughtItemsViewModel> _boughtItemsViewModels;
        private readonly ObservableCollection<SoldItemsViewModel> _soldItemsViewModels;
        private readonly InventoryModel _inventory;
      

        public ICommand LoadAllItemsCommand { get; }
      
        public CompositeCollection ItemsCollection => _itemsCollection;
        
        public HistoryViewModel(InventoryModel inventory)
        {
            _inventory = inventory;
            _itemsCollection = new CompositeCollection();
            _boughtItemsViewModels = new ObservableCollection<BoughtItemsViewModel>();
            _soldItemsViewModels = new ObservableCollection<SoldItemsViewModel>();
          
            LoadAllItemsCommand = new LoadAllItemsCommand(this, inventory);
        }

        public static HistoryViewModel LoadViewModel(InventoryModel inventory)
        {
            HistoryViewModel viewModel = new HistoryViewModel(inventory);

            viewModel.LoadAllItemsCommand.Execute(null);

            return viewModel;
        }

        public void UpdateItems(IEnumerable<BoughtItemsModel> boughtItems, IEnumerable<SoldItemsModel> soldItems)
        {
            _itemsCollection.Clear();
            _boughtItemsViewModels.Clear();
            _soldItemsViewModels.Clear();
            
            CollectionContainer boughtItemsContainer = new CollectionContainer();
            CollectionContainer soldItemsContainer = new CollectionContainer();

            foreach (BoughtItemsModel boughtItem in boughtItems)
            {
                BoughtItemsViewModel boughtItemsViewModel = new BoughtItemsViewModel(boughtItem);
                _boughtItemsViewModels.Add(boughtItemsViewModel);
            }
            boughtItemsContainer.Collection = _boughtItemsViewModels;

            foreach (SoldItemsModel soldItem in soldItems)
            {
                SoldItemsViewModel soldItemsViewModel = new SoldItemsViewModel(soldItem);
                _soldItemsViewModels.Add(soldItemsViewModel);
            }
            soldItemsContainer.Collection = _soldItemsViewModels;

            _itemsCollection.Add(boughtItemsContainer);
            _itemsCollection.Add(soldItemsContainer);
            
        }
      
    }
}
