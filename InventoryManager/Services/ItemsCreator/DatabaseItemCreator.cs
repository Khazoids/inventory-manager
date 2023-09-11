using InventoryManager.DTOs;
using InventoryManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManager.Services.ItemsCreator {

    /// <summary>
    /// This class provides a DBContextFactory which can then call methods to open a connection to the database.
    /// 
    /// While the connection is open, DTOs are created with data that is then inserted into the database.
    /// 
    /// The DBContext connection is discarded once finished.
    /// </summary>
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
                    boughtItem.PurchasePrice,
                    boughtItem.PurchaseDate,
                    boughtItem.IsListed
                    );

                context.BoughtItems.Add(boughtItemDTO);
                await context.SaveChangesAsync();
            }
        }
        
        public async Task CreateSoldItem(SoldItemsModel soldItem)
        {
            using (InventoryManagerDbContext context = _dbContextFactory.CreateDbContext())
            {
                SoldItemsDTO soldItemDTO = new SoldItemsDTO(
                    new ItemsDTO(soldItem.Item.ItemName, soldItem.Item.ItemType),
                    soldItem.ShippingStatus,
                    soldItem.SalePrice,
                    soldItem.SaleDate);

                context.SoldItems.Add(soldItemDTO); 
                await context.SaveChangesAsync();
            }
        }
        
    }
}
