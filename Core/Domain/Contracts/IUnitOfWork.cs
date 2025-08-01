﻿using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Contracts
{
    public interface IUnitOfWork
    {
        Task<int> SaveChangesAsync();

        IGenericRepository<IEntity, TKey> GetRepository<IEntity, TKey>()
            where IEntity : BaseEntity<TKey>;
    }
}
