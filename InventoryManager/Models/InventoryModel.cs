﻿using InventoryManager.Services.ItemProviders;
using InventoryManager.Services.ItemsCreator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

/*
 * This domain model represents the application iteself. This model incorporates CRUD methods that is then visually represented in the application.
 */
namespace InventoryManager.Models {
    public class InventoryModel {
        private readonly IItemProvider _itemProvider;
        private readonly IItemCreator _itemCreator;

       
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
