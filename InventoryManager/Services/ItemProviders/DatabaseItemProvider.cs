using InventoryManager.DTOs;
using InventoryManager.Models;
using InventoryManager.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

/*
 * This class implements methods to retrieve data from the ItemsDB.
 * Data is stored in the form of a DTO which is then mapped to our models.
 */

namespace InventoryManager.Services.ItemProviders {
    public class DatabaseItemProvider:IItemProvider {

        private readonly InventoryManagerDbContextFactory _dbContextFactory;

        public DatabaseItemProvider(InventoryManagerDbContextFactory dbContextFactory) {
            _dbContextFactory = dbContextFactory;
        }
        
        public async Task<CompositeCollection> GetAllItems()
        {   
            
            CompositeCollection compositeCollection = new CompositeCollection();

            Task<IEnumerable<BoughtItemsModel>> boughtItems = GetAllBoughtItems();
            Task<IEnumerable<SoldItemsModel>> soldItems = GetAllSoldItems();

            

            await Task.WhenAll(boughtItems, soldItems);

            compositeCollection.Add(boughtItems);
            compositeCollection.Add(soldItems);

            return compositeCollection;
        }

       public async Task<IEnumerable<BoughtItemsModel>> GetAllBoughtItems() {
            using (InventoryManagerDbContext context = _dbContextFactory.CreateDbContext()) {
                IEnumerable<BoughtItemsDTO> boughtItemsDTOs = await context.BoughtItems.Include(i => i.Item).ToListAsync();

                return boughtItemsDTOs.Select(i => new BoughtItemsModel(
                    i.ShippingStatus, 
                    new ItemsModel(i.Item.ItemName, i.Item.ItemType), 
                    i.Price,
                    i.PurchaseDate,
                    i.IsListed));
            }
        }

        public async Task<IEnumerable<BoughtItemsModel>> GetRecentlyBoughtItems()
        {
            using (InventoryManagerDbContext context = _dbContextFactory.CreateDbContext())
            {
                IEnumerable<BoughtItemsDTO> boughtItemsDTOs = await context.BoughtItems.Include(i => i.Item).Take(5).ToListAsync();

                return boughtItemsDTOs.Select(i => new BoughtItemsModel(
                    i.ShippingStatus,
                    new ItemsModel(i.Item.ItemName, i.Item.ItemType),
                    i.Price,
                    i.PurchaseDate,
                    i.IsListed));
            } 
        }

        public async Task<IEnumerable<SoldItemsModel>> GetAllSoldItems() {
            using (InventoryManagerDbContext context = _dbContextFactory.CreateDbContext()) {
                IEnumerable<SoldItemsDTO> soldItemsDTOs = await context.SoldItems.Include(i => i.Item).ToListAsync();

                return soldItemsDTOs.Select(i => new SoldItemsModel(
                    i.ShippingStatus,
                    new ItemsModel(i.Item.ItemName, i.Item.ItemType),
                    i.Price,
                    i.SaleDate));
            }
        }

        public async Task<IEnumerable<SoldItemsModel>> GetRecentlySoldItems()
        {
            using (InventoryManagerDbContext context = _dbContextFactory.CreateDbContext())
            {
                IEnumerable<SoldItemsDTO> soldItemsDTOs = await context.SoldItems.Include(i => i.Item).Take(5).ToListAsync();

                return soldItemsDTOs.Select(i => new SoldItemsModel(
                    i.ShippingStatus,
                    new ItemsModel(i.Item.ItemName, i.Item.ItemType),
                    i.Price,
                    i.SaleDate));
            }
        }
    }
}
