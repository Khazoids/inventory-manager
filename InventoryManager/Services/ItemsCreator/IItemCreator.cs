using InventoryManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManager.Services.ItemsCreator {
    public interface IItemCreator {
        Task CreateItem(ItemsModel item);

        Task CreateBoughtItem(BoughtItemsModel item);
    }
}
