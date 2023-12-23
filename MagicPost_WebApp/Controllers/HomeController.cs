using LazZiya.ExpressLocalization;
using MagicPost_ApiIntergration;
using MagicPost_ViewModel.Orders;
using MagicPost_WebApp.Models;
using MagicPostUtilities.Constants;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Diagnostics;
using System.Globalization;
using System.Text.RegularExpressions;
using static Microsoft.Extensions.Logging.EventSource.LoggingEventSource;

namespace MagicPost_WebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
		private readonly ISharedCultureLocalizer _loc;
        private readonly ISlideApiClient _slideApiClient;

        private readonly IOrderApiClient _orderApiClient;

		public HomeController(ILogger<HomeController> logger, ISharedCultureLocalizer loc, ISlideApiClient slideApiClient, IOrderApiClient orderApiClient)
        {
            _logger = logger;
			_loc = loc;
            _slideApiClient = slideApiClient;

            _orderApiClient = orderApiClient;
		}

		public async Task<IActionResult> Index()
		{

            var viewModel = new HomeViewModel
            {
                Slides = await _slideApiClient.GetAll(),
               Orders = await _orderApiClient.GetPagings(new GetManageOrderPagingRequest() { 
                     Keyword="",
                     PageIndex = 1,
                     PageSize =10
               })
              
            };

            return View(viewModel);
        }
      
        public async Task<IActionResult> About(string keyword = "", int? OrderStatusId =null, int pageIndex = 1, int pageSize = 10)
        {
            var request = new GetManageOrderPagingRequest()
            {
                Keyword = keyword,
                OrderStatusId = OrderStatusId,
                PageIndex = 1,
                PageSize = 10
            };
            var viewModel = new HomeViewModel
            {
                Slides = await _slideApiClient.GetAll(),
                Orders = await _orderApiClient.GetPagings(request)

            };
            ViewBag.Keyword = keyword;

            return View(viewModel);
        }
        [HttpGet("/vi/Home/About/{DiemGiaoDichId}")]
        public async Task<IActionResult> About(int DiemGiaoDichId)
        {

            var viewModel = new HomeViewModel
            {
                Slides = await _slideApiClient.GetAll(),
                Orders = await _orderApiClient.GetPagingDiemGiaoDich(new GetManageOrderPagingRequest()
                {
                    Keyword = "",
                    PageIndex = 1,
                    PageSize = 10
                }, DiemGiaoDichId)

            };
            return View(viewModel);
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

		public IActionResult SetCultureCookie(string cltr, string returnUrl)
		{
			Response.Cookies.Append(
				CookieRequestCultureProvider.DefaultCookieName,
				CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(cltr)),
				new CookieOptions { Expires = DateTimeOffset.UtcNow.AddYears(1) }
				);

			return LocalRedirect(returnUrl);
		}

	}
}