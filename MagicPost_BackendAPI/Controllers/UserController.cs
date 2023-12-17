using MagicPost_Application.DiemGiaoDichs;
using MagicPost_Application.DiemTapKets;
using MagicPost_Application.System.Users;
using MagicPost_ViewModel.Diem;
using MagicPost_ViewModel.System.DiemGiaoDichs;
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
        private readonly IDiemTapKetService _DiemTapKetService;
        private readonly IDiemGiaoDichService _DiemGiaoDichService;

        public UserController(IUserService userService, IDiemTapKetService diemTapKetService, IDiemGiaoDichService diemGiaoDichService)
        {
            _userService = userService;
            _DiemTapKetService  = diemTapKetService;
            _DiemGiaoDichService = diemGiaoDichService;
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
            if (string.IsNullOrEmpty(resultToken.ResultObj))
            {
                return BadRequest(resultToken.Message);
            }
            return Ok(resultToken);

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
        [HttpPost("{DiemGiaoDichId}")]
        [AllowAnonymous]
        public async Task<IActionResult> RegisterGiaoDichVien([FromBody] RegisterRequest request, int DiemGiaoDichId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _userService.RegisterGiaoDichVien(request, DiemGiaoDichId);
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
        [HttpPut("{id}/DiemGiaoDich")]
        [AllowAnonymous]

        public async Task<IActionResult> DiemGiaoDichAssign(Guid id, DiemGiaoDichAssignRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _userService.DiemGiaoDichAssign(id, request.DiemGiaoDichId);
            if (!result.IsSuccessed)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
        [HttpPut("/api/User/DiemTapKet/{id}/{DiemTapKetId}")]
        [AllowAnonymous]

        public async Task<IActionResult> DiemTapKetAssign(Guid id, int DiemTapKetId)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _userService.DiemTapKetAssign(id, DiemTapKetId);
          
            if (!result.IsSuccessed)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
        [HttpPut("/api/User/DiemGiaoDich/{id}/{DiemGiaoDichId}")]
        [AllowAnonymous]

        public async Task<IActionResult> DiemGiaoDichAssign(Guid id, int DiemGiaoDichId)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _userService.DiemGiaoDichAssign(id, DiemGiaoDichId);
           
            if (!result.IsSuccessed)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
        // https://localhost/api/user/paging?pageIndex=1&pageSize=10$keyword =
        [HttpGet("paging")]
        // [Authorize(Roles = "TruongDiemGiaoDich")]
        public async Task<IActionResult> GetAllPaging([FromQuery] GetUserPagingRequest request)
        {
            var orders = await _userService.GetUsersPaging(request);
            return Ok(orders);
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
