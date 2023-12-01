using MagicPost_Application.System.Users;
using MagicPost_ViewModel.System.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace MagicPost_BackendAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserController : Controller
    {

        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("authenticate")]
        [AllowAnonymous]
        public async Task<IActionResult> Authenticate([FromBody] LoginRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var resultToken = await _userService.Authenticate(request);
            if(string.IsNullOrEmpty(resultToken.ResultObj))
            {
                return BadRequest(resultToken.Message);
            }
            return Ok(resultToken );
           
        }
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Register([FromBody] RegisterRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _userService.Register(request);
            if (!result.IsSuccessed)

            {
                return BadRequest(result.Message);
            }
            return Ok(result);
        }
        // https:localhost/api/users/id
        [HttpPut("{id}")]
 
        public async Task<IActionResult> Update(Guid id, [FromBody] UserUpdateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _userService.Update(id, request);
            if (!result.IsSuccessed)

            {
                return BadRequest(result.Message);
            }
            return Ok(result);
        }
   

        [HttpPut("{id}/roles")]
        public async Task<IActionResult> RoleAssign(Guid id, [FromBody] RoleAssignRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _userService.RoleAssign(id, request);
            if (!result.IsSuccessed)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        // https://localhost/api/user/paging?pageIndex=1&pageSize=10$keyword =
        [HttpGet("paging")]

        public async Task<IActionResult> GetAllPaging( [FromQuery] GetUserPagingRequest request)
        {
            var products = await _userService.GetUsersPaging(request);
            return Ok(products);
        }

        [HttpGet("id")]

        public async Task<IActionResult> GetById(Guid Id)
        {
            var users = await _userService.GetById(Id);
            return Ok(users);
        }
        [HttpDelete("{id}")]

        public async Task<IActionResult> Delete(Guid Id)
        {
            var result = await _userService.Delete(Id);
            return Ok(result);
        }
    }
}
