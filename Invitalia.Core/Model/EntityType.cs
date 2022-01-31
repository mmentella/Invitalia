namespace Invitalia.Core.Model
{
    public class EntityType
        : Entity
    {
        public string Description { get; set; }
        public string Value { get; set; }

        public override void Bind(IEntity parent)
        {
            ParentId = "0";
        }
    }
}
