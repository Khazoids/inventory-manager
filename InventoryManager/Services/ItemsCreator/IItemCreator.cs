using InventoryManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * This interface provides all the required methods for this application to create and insert into the ItemsDB.
 */
namespace InventoryManager.Services.ItemsCreator {
    public interface IItemCreator {
        Task CreateItem(ItemsModel item);

        Task CreateBoughtItem(BoughtItemsModel item);

        Task CreateSoldItem(SoldItemsModel item);
    }
}
