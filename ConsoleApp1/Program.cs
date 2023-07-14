using InventoryManager.Services;
using InventoryManager.Models;
using System;

namespace ConsoleApp1 {
    class Program {
        static void Main(string[] args) {
            IDataService<BoughtItemsModel> boughtItemsService = new GenericDataService<BoughtItemsModel>(new InventoryManagerDbContextOptionsFactory());
            boughtItemsService.Create(n);
        }
    }
}