using MagicPost_Application.Transfer;
using MagicPost_ViewModel.Orders;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace MagicPost_BackendAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransferController : Controller
    {

        private readonly ITransferService _TransferService;
        public TransferController(ITransferService TransferService)
        {
            this._TransferService = TransferService;
        }

        [HttpGet("{orderId}/{languageId}")]

        public async Task<IActionResult> GetById(int transferId)
        {
            var product = await _TransferService.GetById(transferId);
            if (product == null)
                return BadRequest("Cannot find product");
            return Ok(product);
        }

        [HttpPost("{idx}")]
        [Consumes("multipart/form-data")]
        //[Authorize(Roles ="GiaoDichVien, NhanVienTapKet")]
        public async Task<IActionResult> Create(int idx, [FromForm] TransferCreateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            request.OrderId = idx;
            var transferId = await _TransferService.Create(idx, request);
            if (transferId == 0)
                return BadRequest();

            var product = await _TransferService.GetById(transferId);

            return CreatedAtAction(nameof(GetById), new { id = transferId }, product);
        }

    }
}
