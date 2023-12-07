using MagicPost_Application.Orders;
using MagicPost_ViewModel.Orders;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace MagicPost_BackendAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : Controller
    {
 
        private readonly IOrderService _OrderService;
        public OrderController(IOrderService OrderService)
        {
            this._OrderService = OrderService;
        }
       
        [HttpGet("paging")]
       

        public async Task<IActionResult> GetAllPaging([FromQuery] GetManageOrderPagingRequest request)
        {
            var products = await _OrderService.GetAllPaging(request); 
            return Ok(products);
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
        // [Authorize(Roles ="GiaoDichVien")]
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
