using MagicPost_Application.Logs;
using MagicPost_Application.Orders;
using MagicPost_Application.System.Users;
using MagicPost_ViewModel.Orders;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata;
using PdfSharpCore;
using PdfSharpCore.Pdf;
using System.IO;
using System.Security.Claims;
using TheArtOfDev.HtmlRenderer.PdfSharp;

namespace MagicPost_BackendAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LogController : Controller
    {
        private readonly IUserService _userService;
        private readonly ILogService _LogService;
        public LogController(ILogService LogService, IUserService userService)
        {
            this._LogService = LogService;
            _userService = userService;

        }

        [HttpGet("paging")]
        // [Authorize(Roles ="GiaoDichVien")]

        public async Task<IActionResult> GetAllPaging([FromQuery] GetManageOrderPagingRequest request)
        {


           /* var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (userId != null)
            {
                var users = await _userService.GetById(Guid.Parse(userId));
                *//*if (users.ResultObj.DiemGiaoDichId.HasValue)
                {
                    var product1 = await _LogService.GetAllPagingDiemGiaoDich(request, users.ResultObj.DiemGiaoDichId.Value);
                    return Ok(product1);
                }
                if (users.ResultObj.DiemTapKetId.HasValue)
                {
                    var product1 = await _LogService.GetAllPagingDiemTapKet(request, users.ResultObj.DiemTapKetId.Value);
                    return Ok(product1);
                }*//*
            }*/
            var products = await _LogService.GetAllPaging(request);
            return Ok(products);
        }
        [HttpGet("PagingSend")]
        // [Authorize(Roles ="GiaoDichVien")]

        public async Task<IActionResult> GetAllPagingGui([FromQuery] GetManageOrderPagingRequest request)
        {

            var products = await _LogService.GetAllPagingGui(request);
            return Ok(products);
        }
        [HttpGet("PagingReceive")]
        // [Authorize(Roles ="GiaoDichVien")]

        public async Task<IActionResult> GetAllPagingNhan([FromQuery] GetManageOrderPagingRequest request)
        {

            var products = await _LogService.GetAllPagingGui(request);
            return Ok(products);
        }
        [HttpGet("DiemGiaoDich/PagingSend/{DiemGiaoDichId}")]
        // [Authorize(Roles ="GiaoDichVien")]

        public async Task<IActionResult> GetAllPagingGiaoDichGui([FromQuery] GetManageOrderPagingRequest request, int DiemGiaoDichId)
        {

            var products = await _LogService.GetAllPagingDiemGiaoDichGui(request, DiemGiaoDichId);
            return Ok(products);
        }
        [HttpGet("DiemGiaoDich/PagingReceive/{DiemGiaoDichId}")]
        // [Authorize(Roles ="GiaoDichVien")]

        public async Task<IActionResult> GetAllPagingGiaoDichNhan([FromQuery] GetManageOrderPagingRequest request, int DiemGiaoDichId)
        {
            var products = await _LogService.GetAllPagingDiemGiaoDichNhan(request, DiemGiaoDichId);
            return Ok(products);
        }
        [HttpGet("DiemTapKet/PagingSend/{DiemTapKetId}")]
        // [Authorize(Roles ="GiaoDichVien")]

        public async Task<IActionResult> GetAllPagingTapKetGui([FromQuery] GetManageOrderPagingRequest request, int DiemTapKetId)
        {

            var products = await _LogService.GetAllPagingDiemTapKetGui(request, DiemTapKetId);
            return Ok(products);
        }
        [HttpGet("DiemTapKet/PagingReceive/{DiemTapKetId}")]
        // [Authorize(Roles ="GiaoDichVien")]

        public async Task<IActionResult> GetAllPagingTapKetNhan([FromQuery] GetManageOrderPagingRequest request, int DiemTapKetId)
        {
            var products = await _LogService.GetAllPagingDiemTapKetNhan(request, DiemTapKetId);
            return Ok(products);
        }
    }
}
