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

        public async Task<IEnumerable<TEntity>> GetAllAsync(bool trackChanges = false)
        {
            var query = context.Set<TEntity>().AsQueryable();

            if (!trackChanges)
            {
                query = query.AsNoTracking();
            }

            return await query.ToListAsync();
        }
        public async Task<TEntity?> GetAsync(Tkey id) 
            => await context.Set<TEntity>().FindAsync(id);

        public async Task<TEntity?> GetAsync(ISpecifications<TEntity> specifications) =>
            await SpecificationsEvaluator.CreateQuery(context.Set<TEntity>(), specifications).FirstOrDefaultAsync();


        public async Task<IEnumerable<TEntity>> GetAllAsync(ISpecifications<TEntity> specifications) =>
             await SpecificationsEvaluator.CreateQuery(context.Set<TEntity>(), specifications).ToListAsync();

        public async Task<int> CountAsync(ISpecifications<TEntity> specifications)
            => await SpecificationsEvaluator.
            CreateQuery(context.Set<TEntity>(), specifications).CountAsync();
        
       
    }
}