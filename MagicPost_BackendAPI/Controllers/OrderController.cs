using MagicPost_Application.Orders;
using MagicPost_Application.System.Users;
using MagicPost_ViewModel.Orders;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata;
using System.Security.Claims;

namespace MagicPost_BackendAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : Controller
    {
        private readonly IUserService _userService;

        private readonly IOrderService _OrderService;
        public OrderController(IOrderService OrderService, IUserService userService)
        {
            this._OrderService = OrderService;
            _userService = userService;

        }

        [HttpGet("paging")]
        // [Authorize(Roles ="GiaoDichVien")]

        public async Task<IActionResult> GetAllPaging([FromQuery] GetManageOrderPagingRequest request)
        {


            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            
            if (userId != null)
            {
                var users = await _userService.GetById(Guid.Parse(userId));
                if (users.ResultObj.DiemGiaoDichId.HasValue)
                {
                    var product1 = await _OrderService.GetAllPagingDiemGiaoDich(request, users.ResultObj.DiemGiaoDichId.Value);
                    return Ok(product1);
                }
                if (users.ResultObj.DiemTapKetId.HasValue)
                {
                    var product1 = await _OrderService.GetAllPagingDiemTapKet(request, users.ResultObj.DiemTapKetId.Value);
                    return Ok(product1);
                }
            }
            var products = await _OrderService.GetAllPaging(request ); 
            return Ok(products);
        }
        [HttpGet("paging/{DiemGiaoHangId}")]
        // [Authorize(Roles ="GiaoDichVien")]

        public async Task<IActionResult> GetAllPaging([FromQuery] GetManageOrderPagingRequest request, int DiemGiaoHangId)
        {

                    var product1 = await _OrderService.GetAllPagingDiemGiaoDich(request,DiemGiaoHangId);
                    return Ok(product1);
                
            
        }

        //https://localhost:port/product/{id}
        [HttpGet("{orderId}/{languageId}")]

        public async Task<IActionResult> GetById(int orderId)
        {
            var product = await _OrderService.GetById(orderId);
            if (product == null)
                return BadRequest("Cannot find product");
            return Ok(product);
        }
        // ------phân quyền cho Giao dịch viên--------

        [HttpPost]
        [Consumes("multipart/form-data")]
        [Authorize(Roles ="GiaoDichVien")]
        public async Task<IActionResult> Create([FromForm] OrderCreateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var orderId = await _OrderService.Create(request);
            if (orderId == 0)
                return BadRequest();
           
            var product = await _OrderService.GetById(orderId);

            return CreatedAtAction(nameof(GetById), new { id = orderId }, product);
        }

        [HttpDelete("{orderId}")]
       // [Authorize(Roles = "GiaoDichVien")]
        public async Task<IActionResult> Delete(int orderId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var affectResult = await _OrderService.Delete(orderId);
            if (affectResult == 0)
            {
                return BadRequest();
            }
            return Ok();

        }
    }
}
