using PowerPlant.Domain;
using Shared.Domain.Base;
using Shared.Infrastructure;

namespace PowerPlant.Infrastructure
{
    public class AppRepository<TEntity> : RepositoryBase<TEntity, AppDbContext>, IAppRepository<TEntity>
        where TEntity : EntityBase
    {
        public AppRepository(AppDbFactory dbFactory) : base(dbFactory)
        {
            dbFactory.Context.Database.EnsureCreated();
        }
    }
}
