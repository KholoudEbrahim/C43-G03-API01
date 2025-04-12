using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    internal class GenericRepository<TEntity, Tkey>(StoreDbContext context) :
        IGenericRepository<TEntity, Tkey>
        where TEntity : BaseEntity<Tkey>
    {
        public void Add(TEntity entity) => context.Set<TEntity>().Add(entity);

        public void Delete(TEntity entity) => context.Set<TEntity>().Remove(entity);

        public void Update(TEntity entity) => context.Set<TEntity>().Update(entity);

        public async Task<IEnumerable<TEntity>> GetAllAsync()
            => await context.Set<TEntity>().ToListAsync();

        public async Task<TEntity> GetAsync(Tkey key) 
            => await context.Set<TEntity>().FindAsync(key);

    }
}