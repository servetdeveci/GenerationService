using System;

namespace Shared.Domain.Base
{
    public abstract class EntityBase : IEntityBase
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
    }
}
