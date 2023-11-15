using MagicPost_Application.Order;
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

        public async Task<IActionResult> GetById(int productId)
        {
            var product = await _OrderService.GetById(productId);
            if (product == null)
                return BadRequest("Cannot find product");
            return Ok(product);
        }
       
    }
}
