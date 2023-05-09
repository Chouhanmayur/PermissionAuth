using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace User.Management.API.Models
{
    public class PermissionService : IPermissionService
    {
        private readonly ApplicationDbContext _context;
        private readonly TestauthMcContext _contexttest;
        private readonly UserManager<IdentityUser> _userManager;

        public PermissionService(ApplicationDbContext context, UserManager<IdentityUser> userManager, TestauthMcContext contexttest)
        {
            _context = context;
            _userManager = userManager;
            _contexttest = contexttest;
        }
        public async Task<HashSet<string>> GetPermissionsAsync(Guid memberId)
        {
            // var user = await _userManager.FindByIdAsync(memberId.ToString());
            // var roles = await _userManager.GetRolesAsync(user);
            //var roleid= _contexttest.AspNetRoles.Where(x => x.Name == roles.FirstOrDefault())
            //     .FirstOrDefault()?.Id;
            // var rolepermissionid = _contexttest.RolePermissions.Where(x=>x.RoleId==roleid).FirstOrDefault()?.PermissionId;

            // var permissionname = _contexttest.Permissions.Where(x => x.Id == rolepermissionid).Select(x => x.Name).FirstOrDefault();
            // var test = new HashSet<string>() { permissionname };

            var user = await _userManager.FindByIdAsync(memberId.ToString());
            var roles = await _userManager.GetRolesAsync(user);
            //var roleName = roles.FirstOrDefault();
            var roleid = _contexttest.AspNetRoles.Where(x => x.Name == roles.FirstOrDefault()).FirstOrDefault()?.Id;
            //     .FirstOrDefault()?.Id;
            //var permissionName = await _contexttest.Permissions
            //    .Where(p => _contexttest.RolePermissions.Any(rp => rp.RoleId == roleid && rp.PermissionId == p.Id))
            //    .Select(p => p.Name)
            //    .FirstOrDefaultAsync();
            var permissionNames = await _contexttest.Permissions
                                  .Where(p => _contexttest.RolePermissions.Any(rp => rp.RoleId == roleid && rp.PermissionId == p.Id))
                                  .Select(p => p.Name)
                                  .ToListAsync();

            // return new HashSet<string>(new[] { permissionNames });
            return new HashSet<string>(permissionNames);

        }
    }
}
