using InventoryManager.Services.ItemProviders;
using InventoryManager.Services.ItemsCreator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;


namespace InventoryManager.Models {

    /// <summary>
    /// This class represents the Inventory object providing methods that simulate 
    /// actions such as adding, removing, and shipping from inventory.
    /// 
    /// The Inventory model uses the item providers to perform CRUD operations.
    /// </summary>
    public class InventoryModel {
        private readonly IItemProvider _itemProvider;
        private readonly IItemCreator _itemCreator;

       /// <summary>
       /// Two parameter constructor
       /// 
       /// Takes an IITemProvider and IItemCreator to retrieve and insert into the database.
       /// </summary>
       /// <param name="itemProvider">IItemProvider</param>
       /// <param name="itemCreator">IItemCreator</param>
        public InventoryModel(IItemProvider itemProvider, IItemCreator itemCreator) {
            _itemProvider = itemProvider;
            _itemCreator = itemCreator;
        }

        public async Task<CompositeCollection> GetAllItems() {
            return await _itemProvider.GetAllItems();
        }

        public async Task CreateItem(ItemsModel item) {
            await _itemCreator.CreateItem(item);
        }

        public async Task CreateBoughtItem(BoughtItemsModel boughtItem) {
            await _itemCreator.CreateBoughtItem(boughtItem);
        }

        public async Task CreateSoldItem(SoldItemsModel soldItem)
        {
            await _itemCreator.CreateSoldItem(soldItem);
        }
        public async Task<IEnumerable<BoughtItemsModel>> GetAllBoughtItems() {
            return await _itemProvider.GetAllBoughtItems();
        }

        public async Task<IEnumerable<BoughtItemsModel>> GetRecentlyBoughtItems()
        {
            return await _itemProvider.GetRecentlyBoughtItems();
        }

        public async Task<IEnumerable<SoldItemsModel>> GetAllSoldItems()
        {
            return await _itemProvider.GetAllSoldItems();
        }

        public async Task<IEnumerable<SoldItemsModel>> GetRecentlySoldItems()
        {
            return await _itemProvider.GetRecentlySoldItems();
        }


    }
}
