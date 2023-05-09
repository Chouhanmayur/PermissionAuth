using Azure.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using User.Management.API.Models.Authentication;
using User.Management.API.Models.DTO;

namespace User.Management.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PermissionController : ControllerBase
    {
        //[Authorize]
        [HasPermission(Permission.AccessMembers)]
        [HttpGet]
        public string GetPermission()
        {
            return "ok";
        }
    }
}
