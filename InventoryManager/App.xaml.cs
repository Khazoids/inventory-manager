using InventoryManager.Models;
using InventoryManager.Services;
using InventoryManager.Services.ItemProviders;
using InventoryManager.Services.ItemsCreator;
using InventoryManager.Stores;
using InventoryManager.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace InventoryManager {
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App:Application {
        private const string CONNECTION_STRING = "Server=.\\SQLEXPRESS;Database=ItemsDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";
        private readonly NavigationStore _navigationStore;
        private readonly InventoryManagerDbContextFactory _inventoryManagerDbContextFactory;
        private readonly InventoryModel _inventory;

        public App() {
            _inventoryManagerDbContextFactory = new InventoryManagerDbContextFactory(CONNECTION_STRING);
            IItemProvider itemProvider = new DatabaseItemProvider(_inventoryManagerDbContextFactory);
            IItemCreator itemCreator = new DatabaseItemCreator(_inventoryManagerDbContextFactory);

            _inventory = new InventoryModel(itemProvider, itemCreator);     
            _navigationStore = new NavigationStore();
           
        }

        private NavigationBarViewModel CreateNavigationBarViewModel()
        {
            return new NavigationBarViewModel(
                CreateHomeNavigationService(),
                CreateInventoryNavigationService(),
                CreateHistoryNavigationService(),
                CreateExpensesNavigationService()
                );
        }

        private SearchBarViewModel CreateSearchBarViewModel()
        {
            return new SearchBarViewModel();
        }

        private INavigationService<ExpensesViewModel> CreateExpensesNavigationService()
        {
            return new LayoutNavigationService<ExpensesViewModel>(_navigationStore, () => new ExpensesViewModel(), CreateNavigationBarViewModel, CreateSearchBarViewModel);
        }

        private INavigationService<HistoryViewModel> CreateHistoryNavigationService()
        {
            return new LayoutNavigationService<HistoryViewModel>(_navigationStore, () => new HistoryViewModel(), CreateNavigationBarViewModel, CreateSearchBarViewModel);
        }

        private INavigationService<InventoryViewModel> CreateInventoryNavigationService()
        {
            return new LayoutNavigationService<InventoryViewModel>(_navigationStore, () => new InventoryViewModel(), CreateNavigationBarViewModel, CreateSearchBarViewModel);
        }

        private INavigationService<HomeViewModel> CreateHomeNavigationService()
        {
            return new LayoutNavigationService<HomeViewModel>(_navigationStore, 
                () => new HomeViewModel(RecentlyBoughtViewModel.LoadViewModel(_inventory), new RecentlySoldViewModel()),
                CreateNavigationBarViewModel,
                CreateSearchBarViewModel);
        }

        protected override void OnStartup(StartupEventArgs e) {
            DbContextOptions options = new DbContextOptionsBuilder().UseSqlServer(CONNECTION_STRING).Options;
            InventoryManagerDbContext dbContext = _inventoryManagerDbContextFactory.CreateDbContext();

            dbContext.Database.Migrate();

            INavigationService<HomeViewModel> homeNavigation = CreateHomeNavigationService();
            homeNavigation.Navigate();
            MainWindow = new MainWindow() {
                DataContext = new MainViewModel(_navigationStore)
            };

            MainWindow.Show();
            base.OnStartup(e);
        }
    }
}
