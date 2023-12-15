using MagicPost_Application.DiemGiaoDichs;
using MagicPost_Application.Orders;
using MagicPost_ViewModel.Common;
using MagicPost_ViewModel.Orders;
using Microsoft.AspNetCore.Mvc;

namespace MagicPost_BackendAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiemGiaoDichController : Controller
    {

        private readonly IDiemGiaoDichService _DiemGiaoDichService;
        public DiemGiaoDichController(IDiemGiaoDichService DiemGiaoDichService)
        {
            this._DiemGiaoDichService = DiemGiaoDichService;
        }
        [HttpGet("paging")]
        public async Task<IActionResult> GetAllPaging([FromQuery] PagingRequestBase request)
        {
            var products = await _DiemGiaoDichService.GetAllPaging(request);
            return Ok(products);
        }
        [HttpGet("paging/{DiemTapKetId}")]
        public async Task<IActionResult> GetAllPaging([FromQuery] PagingRequestBase request, int DiemTapKetId)
        {
            var products = await _DiemGiaoDichService.GetAllPaging(request, DiemTapKetId);
            return Ok(products);
        }
       
    }
}
