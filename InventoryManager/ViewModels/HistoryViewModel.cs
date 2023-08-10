using InventoryManager.Commands;
<<<<<<< HEAD
=======
using InventoryManager.Converters;
>>>>>>> fb48f3ac1f1b85e945a65d1950078871c964a6bc
using InventoryManager.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
<<<<<<< HEAD
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
=======
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
      
>>>>>>> fb48f3ac1f1b85e945a65d1950078871c964a6bc
    }
}
