using MagicPost_Application.System.Roles;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;


namespace MagicPost_BackendAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
   
    public class RolesController : Controller
    {
        private readonly IRoleService _roleService;
        public RolesController(IRoleService roleService)
        {
            _roleService = roleService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var roles = await  _roleService.GetAll();
            return Ok(roles);
        }

    }
}
