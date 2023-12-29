using System.Collections.Specialized;
using MagicPost__Data.Entities;
using MagicPost_ApiIntergration;
using MagicPost_ViewModel.Common;
using MagicPost_ViewModel.Orders;
using MagicPost_ViewModel.System.Users;
using Microsoft.AspNetCore.Mvc;
using MagicPost__Data.EF;
using Microsoft.EntityFrameworkCore.Metadata.Internal;


namespace MagicPost_WebApp.Controllers
{
   
        public class TransferController : Controller
        {
            private readonly ITransferApiClient _orderApiClient;
            private readonly MagicPostDbContext _context;
          
            public TransferController(ITransferApiClient orderApiClient, MagicPostDbContext context)
            {
                _orderApiClient = orderApiClient;
                _context = context;
            }

            [HttpGet]
            public async Task<IActionResult> Create(int id)
            {
                ViewBag.ListTK = null;
                ViewBag.ListGD = null;
                var temp = await GetTransferRequest(id);
                ViewBag.orderId = id;
                var ord = await _context.Orders.FindAsync(id);
                ViewBag.Status = ord.Status;
                var tempId = ord.DiemTapKetId;
                if (tempId != null)
                {
                var diemTapKetAddresses = _context.DiemTapKets
                    .Where(d => d.Id != tempId)
                    .Select(d => d.Address)
                    .ToList();
                ViewBag.ListTK = diemTapKetAddresses;

                var diemGiaoDichAddresses = _context.DiemGiaoDichs
                    .Where(d => d.DiemTapKetId == tempId)
                    .Select(d => d.Address)
                    .ToList();
                ViewBag.ListGD = diemGiaoDichAddresses;
                }
                return View(temp);
            }

            [HttpPost]
            //  [Consumes("multipart/form-data")]
            public async Task<IActionResult> Create([FromForm] TransferCreateRequest request)
            {

                if (!ModelState.IsValid)
                    return View(request);
                
                if(ViewBag.ListGD != null)
                {
                var diemGiaoDich = await _context.DiemGiaoDichs.FindAsync(request.ToGD);
                request.ToDiemGd = diemGiaoDich.Id;
                    
                }

                if (ViewBag.ListTK != null)
                {
                var diemTapKet = await _context.DiemTapKets.FindAsync(request.ToTk);
                request.ToDiemTk = diemTapKet.Id;

                }
            var result = await _orderApiClient.CreateTransfer(request.OrderId, request);
                if (result)
                {
                    TempData["result"] = "Chuyển sản phẩm thành công";
                    return RedirectToAction("About", "Home");

                }

                ModelState.AddModelError("", "Thêm sản phẩm thất bại");
                var temp = await GetTransferRequest(request.OrderId);
                return View(temp);
            }

            private async Task<TransferCreateRequest> GetTransferRequest(int id)
            {
                var transferRequest = new TransferCreateRequest();
                transferRequest.OrderId = id;
                return transferRequest;
            }
        }
}
