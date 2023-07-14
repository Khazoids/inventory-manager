using InventoryManager.Models;
using InventoryManager.Services;
using Microsoft.EntityFrameworkCore.Design;
using System;

namespace ConsoleApp1 {
    class Program {
        static void Main(string[] args) {
            IDataService<BoughtItemsModel> boughtItemsService = new GenericDataService<BoughtItemsModel>(new InventoryManagerDbContextOptionsFactory());
            boughtItemsService.Create(new BoughtItemsModel {
                ShippingStatus = "Shipped",
                Price = 10.25m,
                PurchaseDate = new DateOnly(2023, 02, 08),
                IsListed = false,
                Items = new ItemsModel {
                    ItemName = "Test Figure",
                    ItemType = "Figurine"
                }
            }).Wait();
        }
    }
}