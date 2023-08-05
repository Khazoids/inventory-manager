using InventoryManager.DTOs;
using InventoryManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * This class implements all the methods needed to asynchronously create and insert items into the itemsDB.
 * Data is stored in our models which is then mapped to DTOs before being inserted into the DB.
 */
namespace InventoryManager.Services.ItemsCreator {
    public class DatabaseItemCreator:IItemCreator {

        private readonly InventoryManagerDbContextFactory _dbContextFactory;
        
        public DatabaseItemCreator(InventoryManagerDbContextFactory dbContextFactory) {
            _dbContextFactory = dbContextFactory;
        }

        public async Task CreateItem(ItemsModel item) {
            using (InventoryManagerDbContext context = _dbContextFactory.CreateDbContext()) {
                ItemsDTO itemsDTO = new ItemsDTO(item.ItemName, item.ItemType);

                context.Items.Add(itemsDTO);
                await context.SaveChangesAsync();
            }
        }

        public async Task CreateBoughtItem(BoughtItemsModel boughtItem) {
            using (InventoryManagerDbContext context = _dbContextFactory.CreateDbContext()) {

                BoughtItemsDTO boughtItemDTO = new BoughtItemsDTO(
                    boughtItem.ShippingStatus,
                    new ItemsDTO(boughtItem.Item.ItemName, boughtItem.Item.ItemType),
                    boughtItem.Price,
                    boughtItem.PurchaseDate,
                    boughtItem.IsListed
                    );

                context.BoughtItems.Add(boughtItemDTO);
                await context.SaveChangesAsync();
            }
        }
        

        public async Task CreateBoughtItem(BoughtItemsModel boughtItem, string itemName, string itemType)
        {
            using (InventoryManagerDbContext context = _dbContextFactory.CreateDbContext())
            {
                ItemsDTO itemDTO = new ItemsDTO(itemName, itemType);

                BoughtItemsDTO boughtItemDTO = new BoughtItemsDTO(
                    boughtItem.ShippingStatus,
                    itemDTO,
                    boughtItem.Price,
                    boughtItem.PurchaseDate,
                    boughtItem.IsListed);

                context.BoughtItems.Add(boughtItemDTO);
                context.Items.Add(itemDTO);
                await context.SaveChangesAsync();
            }
        }
        
    }
}
