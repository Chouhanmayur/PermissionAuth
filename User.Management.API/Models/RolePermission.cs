using System;
using System.Collections.Generic;

namespace User.Management.API.Models;

public partial class RolePermission
{
    public string? RoleId { get; set; }

    public int? PermissionId { get; set; }
}
