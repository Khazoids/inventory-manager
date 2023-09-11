using InventoryManager.DTOs;
using InventoryManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManager.Services.FormEditor
{
    /// <summary>
    /// This class returns a DBContext factory that can call methods to open a connection to the database.
    /// 
    /// While the connection is open, data from DTOs are passed to create models which are then inserted
    /// into the database. Once finished, the DBContext connection is discarded.
    /// </summary>
    public class DatabaseFormOptionCreator:IFormOptionCreator
    {
        private readonly InventoryManagerDbContextFactory _dbContextFactory;

        public DatabaseFormOptionCreator(InventoryManagerDbContextFactory dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }
        public async Task CreateItemStatus(FormOptionsModel formOptionsModel)
        {
            using (InventoryManagerDbContext context = _dbContextFactory.CreateDbContext())
            {
                ItemStatusDTO itemStatusDTO = new ItemStatusDTO(formOptionsModel.ItemStatus);

                context.ItemStatuses.Add(itemStatusDTO);
                await context.SaveChangesAsync();
            }
        }

        public async Task CreateItemType(FormOptionsModel formOptionsModel)
        {
            using (InventoryManagerDbContext context = _dbContextFactory.CreateDbContext())
            {
                ItemTypeDTO itemTypeDTO = new ItemTypeDTO(formOptionsModel.ItemType);

                context.ItemTypes.Add(itemTypeDTO);
                await context.SaveChangesAsync();
            }
        }
    }
}
