using System.Collections.Specialized;
using MagicPost__Data.Entities;
using MagicPost_ApiIntergration;
using MagicPost_ViewModel.Common;
using MagicPost_ViewModel.Orders;
using MagicPost_ViewModel.System.Users;
using Microsoft.AspNetCore.Mvc;

namespace MagicPost_WebApp.Controllers
{
   
        public class TransferController : Controller
        {
            private readonly ITransferApiClient _orderApiClient;
          
            public TransferController(ITransferApiClient orderApiClient)
            {
                _orderApiClient = orderApiClient;
            }

            [HttpGet]
            public async Task<IActionResult> Create(int id)
            {
                var temp = await GetTransferRequest(id);
             ViewBag.orderId = id;
            return View(temp);
            }

            [HttpPost]
            //  [Consumes("multipart/form-data")]
            public async Task<IActionResult> Create([FromForm] TransferCreateRequest request)
            {

                if (!ModelState.IsValid)
                    return View(request);
                
                var result = await _orderApiClient.CreateTransfer(request.OrderId, request);
                if (result)
                {
                    TempData["result"] = "Thêm mới sản phẩm thành công";

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
