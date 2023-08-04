using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManager.Services {
    public class InventoryManagerDbContextFactory {
        private readonly string _dbConnectionString;

        public InventoryManagerDbContextFactory(string dbConnectionString) {
            _dbConnectionString = dbConnectionString;
        }

        public InventoryManagerDbContext CreateDbContext() {
            DbContextOptions options = new DbContextOptionsBuilder().UseSqlite(_dbConnectionString).Options;

            return new InventoryManagerDbContext(options);
        }
    }
}
