using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PowerPlant.Domain
{
    public interface IAppUnitOfWork
    {
        Task<int> CommitAsync();
    }
}
