using Microsoft.AspNetCore.Authorization;
using Microsoft.IdentityModel.JsonWebTokens;
using System.Runtime.ConstrainedExecution;
using System.Security.Claims;

namespace User.Management.API.Models.Authentication
{
    public class PermissiomAuthorizationHandler : AuthorizationHandler<PermissionRequirement>
    {

        private readonly IServiceScopeFactory _serviceScopeFactory;

        public PermissiomAuthorizationHandler(IServiceScopeFactory serviceScopeFactory)
        {
            _serviceScopeFactory = serviceScopeFactory;
        }
        protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context, PermissionRequirement requirement)
        {
            //Need to use dynamic id
            string? memberId = context.User.Claims.FirstOrDefault(
                x => x.Type == ClaimTypes.NameIdentifier)?.Value;

            //test data
          //  memberId = "28ac0905-e9b3-4890-92e8-8145e9536cee";

            if (!Guid.TryParse(memberId, out Guid parsedMemberId))
            {
                return;
            }

            using IServiceScope scope = _serviceScopeFactory.CreateScope();
            IPermissionService permissionService = scope.ServiceProvider
                .GetRequiredService<IPermissionService>();

            HashSet<string> permissions = await permissionService.GetPermissionsAsync(parsedMemberId);

            if(permissions.Contains(requirement.Permission)) {
                context.Succeed(requirement);
            }
        }
    }
}
