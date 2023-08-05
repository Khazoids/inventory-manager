using InventoryManager.DTOs;
using InventoryManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * This interface provides all the required methods for this application to retrieve data from the SQL database.
 */
namespace InventoryManager.Services.ItemProviders {
    public interface IItemProvider {
        Task<IEnumerable<ItemsModel>> GetAllItems();
        Task<IEnumerable<BoughtItemsModel>> GetAllBoughtItems();
        Task<IEnumerable<BoughtItemsModel>> GetRecentlyBoughtItems();
        Task<IEnumerable<SoldItemsModel>> GetAllSoldItems();
        Task<IEnumerable<SoldItemsModel>> GetRecentlySoldItems();

    }
}
