
using MagicPost_ApiIntergration;
using MagicPost_ViewModel.Orders;
using MagicPostUtilities.Constants;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace MagicPost_AdminApp.Controllers
{
	public class OrderController : Controller
    {
        private readonly IOrderApiClient _orderApiClient;
        private readonly IConfiguration _configuration;
        
        public OrderController(IOrderApiClient orderApiClient,
            IConfiguration configuration)
        {
            _configuration = configuration;
            _orderApiClient = orderApiClient;
            
        }

        public async Task<IActionResult> Index(string keyword, int pageIndex = 1, int pageSize = 10)
        {
            
            var languageId = HttpContext.Session.GetString(SystemConstants.AppSettings.DefaultLanguageId);

            
            var request = new GetManageOrderPagingRequest()
            {
                Keyword = keyword,
                PageIndex = pageIndex,
                PageSize = pageSize,
                
            };
            var data = await _orderApiClient.GetPagings(request);
            ViewBag.Keyword = keyword;

           

            if (TempData["result"] != null)
            {
                ViewBag.SuccessMsg = TempData["result"];
            }
            return View(data);
        }

       /* [HttpGet]
        public IActionResult Create()
        {
            return View();
        }*/

/*        [HttpPost]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> Create([FromForm] OrderCreateRequest request)
        {
        
            if (!ModelState.IsValid)
                return View(request);

            var result = await _orderApiClient.CreateProduct(request);
            if (result)
            {
                TempData["result"] = "Thêm mới sản phẩm thành công";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Thêm sản phẩm thất bại");
            return View(request);
        }*/

    

       /* [HttpGet]
        public IActionResult Delete(int id)
        {
            return View(new OrderDeleteRequest()
            {
                Id = id
            });
        }

        [HttpPost]
        public async Task<IActionResult> Delete(OrderDeleteRequest request)
        {
            if (!ModelState.IsValid)
                return View();

            var result = await _orderApiClient.DeleteProduct(request.Id);
            if (result)
            {
                TempData["result"] = "Xóa sản phẩm thành công";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Xóa không thành công");
            return View(request);
        }*/

    }
}
