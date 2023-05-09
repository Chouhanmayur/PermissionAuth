using Microsoft.AspNetCore.Authorization;

namespace User.Management.API.Models.Authentication
{
    public class PermissionRequirement : IAuthorizationRequirement
    {

        public PermissionRequirement(string permission) {
            Permission = permission;
        }

        public string Permission { get; set; }
    }
}
