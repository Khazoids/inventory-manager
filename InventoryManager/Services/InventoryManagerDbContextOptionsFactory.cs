using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManager.Services {
    public class InventoryManagerDbContextOptionsFactory:IDesignTimeDbContextFactory<InventoryManagerDbContext> {
        public InventoryManagerDbContext CreateDbContext(string[] args = null) {
            var options = new DbContextOptionsBuilder<InventoryManagerDbContext>();
            options.UseSqlite("Data Source=inventoryManager.db");

            return new InventoryManagerDbContext(options.Options);
        }
    }
}
 