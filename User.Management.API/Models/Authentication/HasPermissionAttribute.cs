using Microsoft.AspNetCore.Authorization;

namespace User.Management.API.Models.Authentication
{
    public sealed class HasPermissionAttribute : AuthorizeAttribute
    {
        public HasPermissionAttribute(Permission permission)
        : base(policy: permission.ToString()) { }

    }
}
