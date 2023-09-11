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


namespace InventoryManager.Services.ItemProviders {

    /// <summary>
    /// This class provides a DBContext factory which can be used to call methods that open a connection to the database.
    /// 
    /// While the connection is open, data is retrieved and mapped to their respective DTO.
    /// 
    /// Once finished, the DBContext connection is discarded.
    /// </summary>
    public class DatabaseItemProvider:IItemProvider {

        private readonly InventoryManagerDbContextFactory _dbContextFactory;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="dbContextFactory">InventoryMAnagerDbContextFactory</param>
        public DatabaseItemProvider(InventoryManagerDbContextFactory dbContextFactory) {
            _dbContextFactory = dbContextFactory;
        }
        
        /// <summary>
        /// Get all items from the Items table
        /// </summary>
        /// <returns>A composite collection containing BoughtItemsModels and SoldItemsModels</returns>
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

        /// <summary>
        /// Get all bought items from the BoughtItems table.
        /// </summary>
        /// <returns>An enumerable containing BoughtItemsModels</returns>
       public async Task<IEnumerable<BoughtItemsModel>> GetAllBoughtItems() {
            using (InventoryManagerDbContext context = _dbContextFactory.CreateDbContext()) {
                IEnumerable<BoughtItemsDTO> boughtItemsDTOs = await context
                    .BoughtItems
                    .Include(i => i.Item)
                    .OrderByDescending(i => i.PurchaseDate)
                    .ToListAsync();

                return boughtItemsDTOs.Select(i => new BoughtItemsModel(
                    i.ShippingStatus, 
                    new ItemsModel(i.Item.ItemName, i.Item.ItemType), 
                    i.Price,
                    i.PurchaseDate,
                    i.IsListed));
            }
        }

        /// <summary>
        /// Get recently bought items from the BoughtItemsTable. Number of items returned
        /// is determined by the date passed in by the user.
        /// </summary>
        /// <returns>An enumerable containg BoughtItemsModels</returns>
        public async Task<IEnumerable<BoughtItemsModel>> GetRecentlyBoughtItems()
        {
            using (InventoryManagerDbContext context = _dbContextFactory.CreateDbContext())
            {
                IEnumerable<BoughtItemsDTO> boughtItemsDTOs = await context
                    .BoughtItems
                    .Include(i => i.Item)
                    .OrderByDescending(i => i.PurchaseDate)
                    .Take(5)
                    .ToListAsync();

                return boughtItemsDTOs.Select(i => new BoughtItemsModel(
                    i.ShippingStatus,
                    new ItemsModel(i.Item.ItemName, i.Item.ItemType),
                    i.Price,
                    i.PurchaseDate,
                    i.IsListed));
            } 
        }


        /// <summary>
        /// Get all items from the SoldItems table
        /// </summary>
        /// <returns>An enumerable containing SoldItemsModels<SoldItemsModel></returns>
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

        /// <summary>
        /// Get recently sold items from the SoldItemsTable.
        /// The number of items returned is determined by the date passed in by the user.
        /// </summary>
        /// <returns>An enumerable containing SoldItemsModels</returns>
        public async Task<IEnumerable<SoldItemsModel>> GetRecentlySoldItems()
        {
            using (InventoryManagerDbContext context = _dbContextFactory.CreateDbContext())
            {
                IEnumerable<SoldItemsDTO> soldItemsDTOs = await context
                    .SoldItems
                    .Include(i => i.Item)
                    .OrderByDescending(i => i.SaleDate)
                    .Take(5)
                    .ToListAsync();

                return soldItemsDTOs.Select(i => new SoldItemsModel(
                    i.ShippingStatus,
                    new ItemsModel(i.Item.ItemName, i.Item.ItemType),
                    i.Price,
                    i.SaleDate));
            }
        }
    }
}
