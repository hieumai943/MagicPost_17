using MagicPost_ApiIntergration;
using MagicPost_ViewModel.Common;
using MagicPost_ViewModel.Diem;
using MagicPost_ViewModel.System.Users;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;

using System.Security.Claims;
using System.Text;

namespace MagicPost_AdminApp.Controllers
{
    public class UserController : BaseController
    {
        private readonly IUserApiClient _userApiClient;
        private readonly IConfiguration _configuration;
        private readonly IRoleApiClient _roleApiClient;
        private readonly IDiemTapKetApiClient _DiemTapKetApiClient;
        private readonly IDiemGiaoDichApiClient _DiemGiaoDichApiClient;


        public UserController(IUserApiClient userApiClient, IConfiguration configuration, IRoleApiClient roleApiClient, IDiemTapKetApiClient diemTapKetApiClient, IDiemGiaoDichApiClient diemGiaoDichApiClient)
        {
            _userApiClient = userApiClient;
            _configuration = configuration;
            _roleApiClient = roleApiClient;
            _DiemTapKetApiClient = diemTapKetApiClient;
            _DiemGiaoDichApiClient = diemGiaoDichApiClient;
        }
        public async  Task<IActionResult> Index(string keyword = "" , int pageIndex=1, int pageSize =10)
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
        public async  Task<IActionResult> Edit(Guid id)
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
        public async Task<IActionResult> Edit( UserUpdateRequest request)
        {

            if (!ModelState.IsValid)
            {
                return View();
            }
            var result = await _userApiClient.UpdateUser(request.Id, request);
            if (result.IsSuccessed )
            {
                TempData["result"] = "Chỉnh sửa người dùng thành công";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", result.Message);
            return View(request);
        }
        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            HttpContext.Session.Remove("Token");

            return RedirectToAction("Index", "Login");

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
        [HttpGet]
        public async Task<IActionResult> RoleAssign(Guid id)
        {
            var roleAssignRequest = await GetRoleAssignRequest(id);
            return View(roleAssignRequest);
        }

        [HttpPost]
        public async Task<IActionResult> RoleAssign(RoleAssignRequest request)
        {
            if (!ModelState.IsValid)
                return View();

            var result = await _userApiClient.RoleAssign(request.Id, request);
           
            foreach(var i in request.Roles)
            {
                if(i.Selected == true && (i.Name == "NhanVienTapKet" || i.Name == "TruongDiemTapKet"))
                {
                    TempData["UserId"] = request.Id;
                    return RedirectToAction("DiemTapKetAssign", "User");

                }
            }
            foreach (var i in request.Roles)
            {
                if (i.Selected == true && (i.Name == "GiaoDichVien" || i.Name == "TruongDiemGiaoDich"))
                {
                    TempData["UserId"] = request.Id;
                    return RedirectToAction("DiemGiaoDichAssign", "User");

                }
            }
            if (result.IsSuccessed)
            {
                
                TempData["result"] = "Cập nhật quyền thành công";
                return RedirectToAction("Index");
            }
          
            ModelState.AddModelError("", result.Message);
            
            var roleAssignRequest = await GetRoleAssignRequest(request.Id);

            return View(roleAssignRequest);
        }
        [HttpGet]
        public async Task<IActionResult> DiemTapKetAssign(int pageIndex = 1, int pageSize = 10)
        {
            var sessions = HttpContext.Session.GetString("Token");
            var request = new PagingRequestBase()
            {
                // BearerToken = sessions,

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
        [HttpPost()]
         public async Task<IActionResult> DiemTapKetAssign( DiemTapKetAssignRequest request)
         {
             if (!ModelState.IsValid)
                 return View();

             var result = await _userApiClient.DiemTapKetAssign(request.Id, request);

             if (result.IsSuccessed)
             {
                 TempData["result"] = "chỉnh sửa  thành công";
                 return RedirectToAction("Index");
             }

             ModelState.AddModelError("", result.Message);
             return RedirectToAction("Index", "Home");

         }
        [HttpGet]
        public async Task<IActionResult> DiemGiaoDichAssign(int pageIndex = 1, int pageSize = 10)
        {
            var sessions = HttpContext.Session.GetString("Token");
            var request = new PagingRequestBase()
            {
                // BearerToken = sessions,

                PageIndex = pageIndex,
                PageSize = pageSize
            };

            var data = await _DiemGiaoDichApiClient.GetUsersPagingsAll(request);
            if (TempData["result"] != null)
            {
                ViewBag.SuccessMsg = TempData["result"];
            }
            return View(data.ResultObj);
        }
        [HttpPost()]
        public async Task<IActionResult> DiemGiaoDichAssign(DiemGiaoDichAssignRequest request)
        {
            if (!ModelState.IsValid)
                return View();

            var result = await _userApiClient.DiemGiaoDichAssign(request.Id, request);

            if (result.IsSuccessed)
            {
                TempData["result"] = "chỉnh sửa  thành công";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", result.Message);
            return RedirectToAction("Index", "Home");

        }
        private async Task<RoleAssignRequest> GetRoleAssignRequest(Guid id)
        {
            var userObj = await _userApiClient.GetById(id);
            var roleObj = await _roleApiClient.GetAll();
            var roleAssignRequest = new RoleAssignRequest();
            foreach (var role in roleObj.ResultObj)
            {
                roleAssignRequest.Roles.Add(new SelectItem()
                {
                    Id = role.Id.ToString(),
                    Name = role.Name,
                    Selected = userObj.ResultObj.Roles.Contains(role.Name)
                });
            }
            return roleAssignRequest;
        }
    }
}
