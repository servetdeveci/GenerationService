using Shared.Domain;
using Shared.Domain.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace PowerPlant.Domain
{
    public interface IAppRepository<TEntity> : IRepository<TEntity> where TEntity : EntityBase
    {
    }
}
