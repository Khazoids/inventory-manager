using InventoryManager.DTOs;
using InventoryManager.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManager.Services.ItemProviders {
    public class DatabaseItemProvider:IItemProvider {

        private readonly InventoryManagerDbContextFactory _dbContextFactory;

        public DatabaseItemProvider(InventoryManagerDbContextFactory dbContextFactory) {
            _dbContextFactory = dbContextFactory;
        }
        public async Task<IEnumerable<ItemsModel>> GetAllItems() {
            using (InventoryManagerDbContext context = _dbContextFactory.CreateDbContext()) {
                IEnumerable<ItemsDTO> itemDTOs = await context.Items.ToListAsync();

                return itemDTOs.Select(i => new ItemsModel(i.ItemName, i.ItemType));
            }
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
