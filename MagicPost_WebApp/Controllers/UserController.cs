using MagicPost__Data.EF;
using MagicPost__Data.Entities;
using MagicPost_ApiIntergration;
using MagicPost_ViewModel.Common;
using MagicPost_ViewModel.System.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace MagicPost_WebApp.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserApiClient _userApiClient;
        private readonly IDiemGiaoDichApiClient _diemGiaoDichApiClient;
        private readonly MagicPostDbContext _context;

        private readonly IConfiguration _configuration;
        private readonly IRoleApiClient _roleApiClient;
        public UserController(IUserApiClient userApiClient, IDiemGiaoDichApiClient diemGiaoDichApiClient, IConfiguration configuration, IRoleApiClient roleApiClient, MagicPostDbContext context)
        {
            _userApiClient = userApiClient;
            _diemGiaoDichApiClient = diemGiaoDichApiClient;
            _configuration = configuration;
            _roleApiClient = roleApiClient;
            _context = context;
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
            var data = await _userApiClient.GetUsersPagings(request);
            ViewBag.Keyword = keyword;
            if (TempData["result"] != null)
            {
                ViewBag.SuccessMsg = TempData["result"];
            }
            return View(data.ResultObj);
        }
        public async Task<IActionResult> GetGiaoDichViens(string keyword = "", int pageIndex = 1, int pageSize = 10)
        {
            var sessions = HttpContext.Session.GetString("Token");
            var request = new GetUserPagingRequest()
            {
                /*  BearerToken = sessions,*/
                Keyword = keyword,
                PageIndex = pageIndex,
                PageSize = pageSize
            };
            int DiemGiaoDichId = int.Parse(User.FindFirstValue(ClaimTypes.Hash));
            DiemGiaoDich DiemGiaoDich = _context.DiemGiaoDichs.Where(x => x.Id == DiemGiaoDichId).FirstOrDefault();
            var data = await _userApiClient.GetGiaoDichVienPagings(request, DiemGiaoDichId);
            ViewBag.Keyword = keyword;
            ViewBag.DiemGiaoDich = DiemGiaoDich.Name;
            ViewBag.UserEmail = User.FindFirstValue(ClaimTypes.Email);
            if (TempData["result"] != null)
            {
                ViewBag.SuccessMsg = TempData["result"];
            }
            return View(data.ResultObj);
        }
        public async Task<IActionResult> GetNhanVienTapKet(string keyword = "", int pageIndex = 1, int pageSize = 10)
        {
            var sessions = HttpContext.Session.GetString("Token");
            var request = new GetUserPagingRequest()
            {
                /*  BearerToken = sessions,*/
                Keyword = keyword,
                PageIndex = pageIndex,
                PageSize = pageSize
            };
            int DiemTapKetId = int.Parse(User.FindFirstValue(ClaimTypes.Dns));
            // DiemGiaoDich DiemGiaoDich = _context.DiemGiaoDichs.Where(x => x.Id == DiemGiaoDichId).FirstOrDefault();
            var data = await _userApiClient.GetNhanVienTapKetPagings(request, DiemTapKetId);
            ViewBag.Keyword = keyword;
            ViewBag.UserEmail = User.FindFirstValue(ClaimTypes.Email);
            if (TempData["result"] != null)
            {
                ViewBag.SuccessMsg = TempData["result"];
            }
            return View(data.ResultObj);
        }
        [HttpGet]
        public async Task<IActionResult> Details(Guid id)
        {
            var result = await _userApiClient.GetById(id);
            return View(result.ResultObj);  // cai nay se tra ve Uservm vi pageViewResult tra ve kieu nay
        }
        [HttpGet]
        public IActionResult Create()
        {

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(RegisterRequest request)
        {

            if (!ModelState.IsValid)
            {
                return View();
            }
            var result = await _userApiClient.RegisterUser(request);
            if (result.IsSuccessed)
            {
                TempData["result"] = "Thêm mới người dùng thành công";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", result.Message);
            return View(request);
        }
        [HttpGet]
        public IActionResult CreateGiaoDichVien(RegisterRequest request)
        {
            return View(request);
        }
        [HttpPost()]
        // [Authorize("TruongDiemGiaoDich")]
        public async Task<IActionResult> CreateGiaoDichVienpost(RegisterRequest request)
        {

            if (!ModelState.IsValid)
            {
                return View();
            }
            int DiemGiaoDichId = int.Parse(User.FindFirstValue(ClaimTypes.Hash));

            // Lấy DiemGiaoDichId từ người dùng hiện tại
            var result = await _userApiClient.RegisterGiaoDichVien(request, DiemGiaoDichId);

            if (result.IsSuccessed)
            {
                TempData["result"] = "Thêm mới người dùng thành công";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", result.Message);
            return View(request);
        }
        [HttpGet]
        public IActionResult CreateNhanVienTapKet(RegisterRequest request)
        {
            return View(request);
        }
        [HttpPost()]
        // [Authorize("TruongDiemGiaoDich")]
        public async Task<IActionResult> CreateNhanVienTapKetpost(RegisterRequest request)
        {

            if (!ModelState.IsValid)
            {
                return View();
            }
            int DiemTapKetId = int.Parse(User.FindFirstValue(ClaimTypes.Dns));

            // Lấy DiemGiaoDichId từ người dùng hiện tại
            var result = await _userApiClient.RegisterNhanVienTapKet(request, DiemTapKetId);

            if (result.IsSuccessed)
            {
                TempData["result"] = "Thêm mới người dùng thành công";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", result.Message);
            return View(request);
        }
        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var result = await _userApiClient.GetById(id);
            if (result.IsSuccessed)
            {
                var user = result.ResultObj;
                var updateRequest = new UserUpdateRequest()
                {
                    Dob = user.Dob,
                    Email = user.Email,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    PhoneNumber = user.PhoneNumber,
                    Id = id
                };
                return View(updateRequest);
            }
            return RedirectToAction("Error", "Home");
        }
        [HttpPost]
        public async Task<IActionResult> Edit(UserUpdateRequest request)
        {

            if (!ModelState.IsValid)
            {
                return View();
            }
            var result = await _userApiClient.UpdateUser(request.Id, request);
            if (result.IsSuccessed)
            {
                TempData["result"] = "Chỉnh sửa người dùng thành công";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", result.Message);
            return View(request);
        }
        [HttpGet]
        public IActionResult Delete(Guid id)
        {
            return View(new UserDeleteRequest()
            {
                Id = id
            });
        }
        [HttpPost]
        public async Task<IActionResult> Delete(UserDeleteRequest request)
        {

            if (!ModelState.IsValid)
            {
                return View();
            }
            var result = await _userApiClient.Delete(request.Id);
            if (result.IsSuccessed)
            {
                TempData["result"] = "Xóa người dùng thành công";

                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", result.Message);
            return View(request);

        }
    }
}
