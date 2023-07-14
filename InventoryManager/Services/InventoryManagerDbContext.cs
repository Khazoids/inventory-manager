using InventoryManager.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManager.Services {
    public class InventoryManagerDbContext:DbContext {
        public DbSet<ItemsModel> Items {  get; set; }

        public DbSet<BoughtItemsModel> BoughtItems { get; set; }

        public DbSet<SoldItemsModel> SoldItems { get; set; }

        public InventoryManagerDbContext(DbContextOptions options) : base(options) { }
        protected override void ConfigureConventions(ModelConfigurationBuilder builder) {
            builder.Properties<DateOnly>().
                HaveConversion<DateOnlyConverter>()
                .HaveColumnType("date");
        }
    }


    public class DateOnlyConverter:ValueConverter<DateOnly, DateTime> {
        public DateOnlyConverter() : base(
            d => d.ToDateTime(TimeOnly.MinValue),
            d => DateOnly.FromDateTime(d)) 
            { }
    }
}
