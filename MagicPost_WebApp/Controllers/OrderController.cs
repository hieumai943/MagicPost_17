using Microsoft.AspNetCore.Mvc;

using MagicPost_ApiIntergration;

using shopCommerce_ApiIntergration;
using MagicPost_ViewModel.Orders;

namespace MagicPost_WebApp.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderApiClient _orderApiClient;
        

        public OrderController(IOrderApiClient orderApiClient)
        {
			_orderApiClient = orderApiClient;
       
        }

        /* public async Task<IActionResult> Detail(int id, string culture)
         {
             var order = await _orderApiClient.GetById(id, culture);
             return View(new OrderDetailViewModel()
             {
                 Product = product
             });
         }*/
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> Create([FromForm] OrderCreateRequest request)
        {

            if (!ModelState.IsValid)
                return View(request);

            var result = await _orderApiClient.CreateOrder(request);
            if (result)
            {
                TempData["result"] = "Thêm mới sản phẩm thành công";
                
                return RedirectToAction("About", "Home");

            }

            ModelState.AddModelError("", "Thêm sản phẩm thất bại");
            return View(request);
        }
        [HttpGet("getpdf")]
        public async Task<IActionResult> GetPdf(string nameOfFile, int OrderId)
        {
            var fileBytes = await _orderApiClient.GetPdf(nameOfFile,OrderId);

            if (fileBytes != null)
            {
                var fileName = $"Đơn hàng {nameOfFile}.pdf";
                return File(fileBytes, "application/pdf", fileName);
            }

            return BadRequest();
        }
    }
}
