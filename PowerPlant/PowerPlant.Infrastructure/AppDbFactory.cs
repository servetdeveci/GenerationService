using Shared.Infrastructure;
using System;

namespace PowerPlant.Infrastructure
{
    public class AppDbFactory : DbFactoryBase<AppDbContext>
    {
        public AppDbFactory(Func<AppDbContext> dbContextFactory) : base(dbContextFactory)
        {
        }
    }
}
