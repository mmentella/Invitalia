using Microsoft.Azure.CosmosRepository;
using System;

namespace Invitalia.Core
{
    public abstract class Entity
        : Item
        , IEntity
    {
        public virtual string ParentId { get; set; } = "0";
        public DateTime CreatedUtc { get; set; }
        public DateTime UpdatedUtc { get; set; }

        public virtual void Bind(IEntity parent)
        {
            ParentId = parent.Id;
            Modified();
        }

        protected void Modified()
        {
            UpdatedUtc = DateTime.UtcNow;
        }
    }
}
