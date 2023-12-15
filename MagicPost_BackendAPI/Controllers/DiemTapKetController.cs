using MagicPost_Application.DiemGiaoDichs;
using MagicPost_Application.DiemTapKets;
using MagicPost_ViewModel.Common;
using Microsoft.AspNetCore.Mvc;

namespace MagicPost_BackendAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiemTapKetController : Controller
    {

        private readonly IDiemTapKetService _DiemTapKetService;
        public DiemTapKetController(IDiemTapKetService DiemTapKetService)
        {
            this._DiemTapKetService = DiemTapKetService;
        }

        [HttpGet("paging")]
        public async Task<IActionResult> GetAllPaging([FromQuery] PagingRequestBase request)
        {
            var products = await _DiemTapKetService.GetAllPaging(request);
            return Ok(products);
        }
        [HttpGet("{DiemTapKetId}")]

        public async Task<IActionResult> GetById(int DiemTapKetId)
        {
            var DiemTapKet = await _DiemTapKetService.GetById(DiemTapKetId);
            
            if (DiemTapKet == null)
                return BadRequest("Cannot find Diem tap ket");
            return Ok(DiemTapKet);
        }
    }
}
