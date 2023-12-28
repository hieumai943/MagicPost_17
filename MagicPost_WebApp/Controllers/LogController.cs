using Microsoft.AspNetCore.Mvc;

using MagicPost_ApiIntergration;

using shopCommerce_ApiIntergration;
using MagicPost_ViewModel.Orders;
using MagicPost_WebApp.Models;

namespace MagicPost_WebApp.Controllers
{
    public class LogController : Controller
    {
        private readonly ILogApiClient _logApiClient;


        public LogController(ILogApiClient logApiClient)
        {
            _logApiClient = logApiClient;

        }

        /* public async Task<IActionResult> Detail(int id, string culture)
         {
             var order = await _orderApiClient.GetById(id, culture);
             return View(new OrderDetailViewModel()
             {
                 Product = product
             });
         }*/
        public async Task<IActionResult> GetAllPaging(string keyword = "", int pageIndex = 1, int pageSize = 10)
        {
            var request = new GetManageOrderPagingRequest()
            {
                Keyword = keyword,
                PageIndex = 1,
                PageSize = 10
            };
            var viewModel = new HomeViewModel
            {
                Orders = await _logApiClient.GetPagings(request)

            };
            ViewBag.Keyword = keyword;

            return View(viewModel);
        }
    }
}
