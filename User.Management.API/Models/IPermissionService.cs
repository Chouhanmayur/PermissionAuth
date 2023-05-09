namespace User.Management.API.Models
{
    public interface IPermissionService
    {
        Task<HashSet<string>> GetPermissionsAsync(Guid memberId);
    }
}
