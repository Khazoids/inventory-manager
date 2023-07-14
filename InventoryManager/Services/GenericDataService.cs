using InventoryManager.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManager.Services {
    public class GenericDataService<T> :IDataService<T> where T : DomainObject {

        private readonly InventoryManagerDbContextOptionsFactory _optionsFactory;

        public GenericDataService(InventoryManagerDbContextOptionsFactory optionsFactory) {
            _optionsFactory = optionsFactory;
        }
        public async Task<T> Create(T entity) {
            using (InventoryManagerDbContext context = _optionsFactory.CreateDbContext()) {
                await context.Set<T>().AddAsync(entity);
                await context.SaveChangesAsync();
            }

            return entity;
        }

        public async Task<bool> Delete(int id) {
            
            using(InventoryManagerDbContext context = _optionsFactory.CreateDbContext()) {
                T entity = await context.Set<T>().FirstOrDefaultAsync((e) => e.Id == id);
                context.Set<T>().Remove(entity);
                await context.SaveChangesAsync();

                return true;
            }
        }

        public async Task<T> Get(int id) {
            using (InventoryManagerDbContext context = _optionsFactory.CreateDbContext()) {
                T entity = await context.Set<T>().FirstOrDefaultAsync((e) => e.Id == id);
                return entity;
            }
        }

        public async Task<IEnumerable<T>> GetAll() {
            using (InventoryManagerDbContext context = _optionsFactory.CreateDbContext()) {
                IEnumerable<T> entities = await context.Set<T>().ToListAsync();

                return entities;
            }
        }

        public async Task<T> Update(int id, T entity) {
            using (InventoryManagerDbContext context = _optionsFactory.CreateDbContext()) {
                entity.Id = id;
                context.Set<T>().Update(entity);
                await context.SaveChangesAsync();

                return entity;
            }
        }
    }
}
