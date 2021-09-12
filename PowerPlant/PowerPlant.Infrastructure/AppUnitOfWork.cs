using PowerPlant.Domain;
using Shared.Infrastructure;

namespace PowerPlant.Infrastructure
{
    public class AppUnitOfWork : UnitOfWorkBase<AppDbContext>, IAppUnitOfWork
    {
        public AppUnitOfWork(AppDbFactory dbFactory) : base(dbFactory)
        {
            dbFactory.Context.Database.EnsureCreated();
        }
    }
}
