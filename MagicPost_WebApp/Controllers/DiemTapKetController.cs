using MagicPost_ApiIntergration;
using MagicPost_ViewModel.Common;
using MagicPost_ViewModel.Diem;
using MagicPost_ViewModel.System.Users;
using Microsoft.AspNetCore.Mvc;

namespace MagicPost_WebApp.Controllers
{
    public class DiemTapKetController : Controller
    {
        private readonly IDiemTapKetApiClient _DiemTapKetApiClient;
        private readonly IUserApiClient _UserApiClient;

        private readonly IConfiguration _configuration;
        private readonly IRoleApiClient _roleApiClient;
        public DiemTapKetController(IDiemTapKetApiClient DiemTapKetApiClient, IUserApiClient userApiClient, IConfiguration configuration, IRoleApiClient roleApiClient)
        {
            _DiemTapKetApiClient = DiemTapKetApiClient;
            _UserApiClient = userApiClient;
            _configuration = configuration;
            _roleApiClient = roleApiClient;
        }
        public async Task<IActionResult> Index(int pageIndex = 1, int pageSize = 10)
        {
            var sessions = HttpContext.Session.GetString("Token");
            var request = new PagingRequestBase()
            {
                /*  BearerToken = sessions,*/

                PageIndex = pageIndex,
                PageSize = pageSize
            };
            var data = await _DiemTapKetApiClient.GetUsersPagings(request);
            if (TempData["result"] != null)
            {
                ViewBag.SuccessMsg = TempData["result"];
            }
            return View(data.ResultObj);
        }

        /*[HttpPost()]

        public async Task<IActionResult> Assign(DiemGiaoDichAssignRequest request)
        {
            
            var result = await _UserApiClient.DiemTapKetAssign(request.Id, request);
            if (result.IsSuccessed)
            {
                TempData["result"] = "Chỉnh sửa người dùng thành công";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", result.Message);
     
            return RedirectToAction("Index", "Home");

        }*/
    }
}
