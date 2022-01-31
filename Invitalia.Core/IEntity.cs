using Microsoft.Azure.CosmosRepository;

namespace Invitalia.Core
{
    public interface IEntity
        : IItem
    {
        string ParentId { get; }
        void Bind(IEntity parent);
    }
}
