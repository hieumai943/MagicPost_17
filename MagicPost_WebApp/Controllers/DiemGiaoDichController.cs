using MagicPost_ApiIntergration;
using MagicPost_ViewModel.System.Users;
using Microsoft.AspNetCore.Mvc;

namespace MagicPost_WebApp.Controllers
{
    public class DiemGiaoDichController : Controller
    {
        private readonly IDiemGiaoDichApiClient _DiemGiaoDichApiClient;
        private readonly IConfiguration _configuration;
        private readonly IRoleApiClient _roleApiClient;
        public DiemGiaoDichController(IDiemGiaoDichApiClient DiemGiaoDichApiClient, IConfiguration configuration, IRoleApiClient roleApiClient)
        {
            _DiemGiaoDichApiClient = DiemGiaoDichApiClient;
            _configuration = configuration;
            _roleApiClient = roleApiClient;
        }
        public async Task<IActionResult> Index(string keyword = "", int pageIndex = 1, int pageSize = 10)
        {
            var sessions = HttpContext.Session.GetString("Token");
            var request = new GetUserPagingRequest()
            {
                /*  BearerToken = sessions,*/
                Keyword = keyword,
                PageIndex = pageIndex,
                PageSize = pageSize
            };
            var data = await _DiemGiaoDichApiClient.GetUsersPagings(request);
            ViewBag.Keyword = keyword;
            if (TempData["result"] != null)
            {
                ViewBag.SuccessMsg = TempData["result"];
            }
            return View(data.ResultObj);
        }
    }
}
