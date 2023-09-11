using InventoryManager.DTOs;
using InventoryManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;


namespace InventoryManager.Services.ItemProviders {

    /// <summary>
    /// This interface contains all the methods required to retrieve data from the database for this project.
    /// </summary>
    public interface IItemProvider {
        /// <summary>
        /// Retrieves all items from the SoldItems and BoughtItems table.
        /// Both lists are then put into a CompositeCollection and returned.
        /// </summary>
        /// <returns>A composite collection containing BoughtItems and SoldItems</returns>
        Task<CompositeCollection> GetAllItems();

        /// <summary>
        /// Retrieves all items from the BoughtItems table.
        /// </summary>
        /// <returns>An enumerable containing BoughtItemsModels</returns>
        Task<IEnumerable<BoughtItemsModel>> GetAllBoughtItems();

        /// <summary>
        /// Retrieves some items from the BoughtItems table determined by date range.
        /// </summary>
        /// <returns>An enumerable containing BoughtItemsModels</returns>
        Task<IEnumerable<BoughtItemsModel>> GetRecentlyBoughtItems();

        /// <summary>
        /// Retrieves all items from the SoldItems table.
        /// </summary>
        /// <returns>An enumerable containing SoldItemsModels</returns>
        Task<IEnumerable<SoldItemsModel>> GetAllSoldItems();

        /// <summary>
        /// Retrieves some items from the SoldItemsModel determined by date range.
        /// </summary>
        /// <returns>An enumerable containing SoldItemsModels</returns>
        Task<IEnumerable<SoldItemsModel>> GetRecentlySoldItems();

    }
}
