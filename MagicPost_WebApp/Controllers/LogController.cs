using Microsoft.AspNetCore.Mvc;

using MagicPost_ApiIntergration;

using shopCommerce_ApiIntergration;
using MagicPost_ViewModel.Orders;
using MagicPost_WebApp.Models;
using Microsoft.AspNetCore.Identity;
using MagicPost__Data.Entities;
using static Microsoft.Extensions.Logging.EventSource.LoggingEventSource;

namespace MagicPost_WebApp.Controllers
{
    public class LogController : Controller
    {
        private readonly ILogApiClient _logApiClient;
       //   private readonly UserManager<AppUser> _userManager;


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
        [HttpGet("/vi/Log/GetAllPaging")]
        public async Task<IActionResult> GetAllPaging()
        {

            return View();
        }
        [HttpGet("/vi/Log/PagingSend")]
        public async Task<IActionResult> GetAllPagingSend(string keyword = "", int pageIndex = 1, int pageSize = 10)
        {
            var request = new GetManageOrderPagingRequest()
            {
                Keyword = keyword,
                PageIndex = 1,
                PageSize = 10
            };
            var viewModel = new HomeViewModel
            {
                Orders = await _logApiClient.GetAllPagingGui(request)

            };
            ViewBag.Keyword = keyword;

            return View(viewModel);
        }
        [HttpGet("/vi/Log/PagingReceive")]
        public async Task<IActionResult> GetAllPagingReceive(string keyword = "", int pageIndex = 1, int pageSize = 10)
        {
            var request = new GetManageOrderPagingRequest()
            {
                Keyword = keyword,
                PageIndex = 1,
                PageSize = 10
            };
            var viewModel = new HomeViewModel
            {
                Orders = await _logApiClient.GetAllPagingNhan(request)

            };
            ViewBag.Keyword = keyword;

            return View(viewModel);
        }
        [HttpGet("/vi/Log/DiemGiaoDichGui/{DiemGiaoDichId}")]

        public async Task<IActionResult> DiemGiaoDichGui(int DiemGiaoDichId, string keyword = "", int pageIndex = 1, int pageSize = 10)
        {
            var request = new GetManageOrderPagingRequest()
            {
                Keyword = keyword,
                PageIndex = 1,
                PageSize = 10
            };
            var viewModel = new HomeViewModel
            {
                Orders = await _logApiClient.GetAllPagingDiemGiaoDichGui(request, DiemGiaoDichId)

            };
            ViewBag.Keyword = keyword;

            return View(viewModel);
        }
        [HttpGet("/vi/Log/DiemTapKetGui/{DiemTapKetId}")]
        public async Task<IActionResult> DiemTapKetGui(int DiemTapKetId, string keyword = "", int pageIndex = 1, int pageSize = 10)
        {
            var request = new GetManageOrderPagingRequest()
            {
                Keyword = keyword,
                PageIndex = 1,
                PageSize = 10
            };
            var viewModel = new HomeViewModel
            {
                Orders = await _logApiClient.GetAllPagingDiemTapKetGui(request, DiemTapKetId)

            };
            ViewBag.Keyword = keyword;

            return View(viewModel);
        }
        [HttpGet("/vi/Log/DiemGiaoDichNhan/{DiemGiaoDichId}")]

        public async Task<IActionResult> DiemGiaoDichNhan(int DiemGiaoDichId, string keyword = "", int pageIndex = 1, int pageSize = 10)
        {
            var request = new GetManageOrderPagingRequest()
            {
                Keyword = keyword,
                PageIndex = 1,
                PageSize = 10
            };
            var viewModel = new HomeViewModel
            {
                Orders = await _logApiClient.GetAllPagingDiemGiaoDichNhan(request, DiemGiaoDichId)

            };
            ViewBag.Keyword = keyword;

            return View(viewModel);
        }
        [HttpGet("/vi/Log/DiemTapKetNhan/{DiemTapKetId}")]
        public async Task<IActionResult> DiemTapKetNhan(int DiemTapKetId, string keyword = "", int pageIndex = 1, int pageSize = 10)
        {
            var request = new GetManageOrderPagingRequest()
            {
                Keyword = keyword,
                PageIndex = 1,
                PageSize = 10
            };
            var viewModel = new HomeViewModel
            {
                Orders = await _logApiClient.GetAllPagingDiemTapKetNhan(request, DiemTapKetId)

            };
            ViewBag.Keyword = keyword;

            return View(viewModel);
        }
    }
}
