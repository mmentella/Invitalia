using Microsoft.AspNetCore.Mvc.Controllers;
using System.Reflection;

namespace Invitalia.Core.API.Features
{
    public class InvitaliaControllerFeatureProvider
        : ControllerFeatureProvider
    {
        public TypeInfo[] excludedTypes;

        public InvitaliaControllerFeatureProvider(params TypeInfo[] excludedTypes)
        {
            this.excludedTypes = excludedTypes ?? Array.Empty<TypeInfo>();
        }

        protected override bool IsController(TypeInfo typeInfo)
        {
            bool include = !excludedTypes.Contains(typeInfo);
            return include && base.IsController(typeInfo);
        }
    }
}
