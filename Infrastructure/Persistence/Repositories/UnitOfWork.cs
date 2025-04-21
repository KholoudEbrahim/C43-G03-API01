using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public class UnitOfWork(StoreDbContext context)
        : IUnitOfWork
    {
        private readonly Dictionary<string, object> _repostitories = [];

        public async Task<int> SaveChangesAsync() => await context.SaveChangesAsync();
        public IGenericRepository<IEntity, TKey> GetRepository<IEntity, TKey>() 
            where IEntity : BaseEntity<TKey>
        {
            var typeName = typeof(IEntity).Name;
            if (_repostitories.ContainsKey(typeName))
                return (IGenericRepository<IEntity, TKey>)_repostitories[typeName];
            var repo = new GenericRepository<IEntity, TKey>(context);
            _repostitories[typeName] = repo;
            return repo;

        }

       
    }
}
