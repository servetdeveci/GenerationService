using Microsoft.EntityFrameworkCore;
using Shared.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Infrastructure
{
    public class UnitOfWorkBase<TContext>: IUnitOfWork<TContext> where TContext : DbContext
    {
        private DbFactoryBase<TContext> _dbFactory;

        public UnitOfWorkBase(DbFactoryBase<TContext> dbFactory)
        {
            _dbFactory = dbFactory;
        }

        public TContext Context { get; }

        public Task<int> CommitAsync()
        {
            return _dbFactory.Context.SaveChangesAsync();
        }

    }
}
