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
    public class OrderController : Controller
    {
        private readonly IUserService _userService;
        private readonly IOrderService _OrderService;
        public OrderController(IOrderService OrderService, IUserService userService)
        {
            this._OrderService = OrderService;
            _userService = userService;

        }

        [HttpGet("paging")]
        // [Authorize(Roles ="GiaoDichVien")]

        public async Task<IActionResult> GetAllPaging([FromQuery] GetManageOrderPagingRequest request)
        {


            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            
            if (userId != null)
            {
                var users = await _userService.GetById(Guid.Parse(userId));
                if (users.ResultObj.DiemGiaoDichId.HasValue)
                {
                    var product1 = await _OrderService.GetAllPagingDiemGiaoDich(request, users.ResultObj.DiemGiaoDichId.Value);
                    return Ok(product1);
                }
                if (users.ResultObj.DiemTapKetId.HasValue)
                {
                    var product1 = await _OrderService.GetAllPagingDiemTapKet(request, users.ResultObj.DiemTapKetId.Value);
                    return Ok(product1);
                }
            }
            var products = await _OrderService.GetAllPaging(request ); 
            return Ok(products);
        }
        [HttpGet("paging/{DiemGiaoHangId}")]
        // [Authorize(Roles ="GiaoDichVien")]

        public async Task<IActionResult> GetAllPaging([FromQuery] GetManageOrderPagingRequest request, int DiemGiaoHangId)
        {

                    var product1 = await _OrderService.GetAllPagingDiemGiaoDich(request,DiemGiaoHangId);
                    return Ok(product1);
                
            
        }

        //https://localhost:port/product/{id}
        [HttpGet("{orderId}/{languageId}")]

        public async Task<IActionResult> GetById(int orderId)
        {
            var product = await _OrderService.GetById(orderId);
            if (product == null)
                return BadRequest("Cannot find product");
            return Ok(product);
        }
        // ------phân quyền cho Giao dịch viên--------

        [HttpPost]
        [Consumes("multipart/form-data")]
        [Authorize(Roles ="GiaoDichVien")]
        public async Task<IActionResult> Create([FromForm] OrderCreateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (userId != null)
            {
                var users = await _userService.GetById(Guid.Parse(userId));
                if (users.ResultObj.DiemGiaoDichId.HasValue)
                {
                    var product1 = await _OrderService.CreateGd(request, users.ResultObj.DiemGiaoDichId.Value);
                    return Ok(product1);
                }
                if (users.ResultObj.DiemTapKetId.HasValue)
                {
                    var product1 = await _OrderService.CreateTk(request, users.ResultObj.DiemTapKetId.Value);
                    return Ok(product1);
                }
            }
            var orderId = await _OrderService.Create(request);
            if (orderId == 0)
                return BadRequest();
           
            var product = await _OrderService.GetById(orderId);

            return CreatedAtAction(nameof(GetById), new { id = orderId }, product);
        }

        [HttpDelete("{orderId}")]
       // [Authorize(Roles = "GiaoDichVien")]
        public async Task<IActionResult> Delete(int orderId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var affectResult = await _OrderService.Delete(orderId);
            if (affectResult == 0)
            {
                return BadRequest();
            }
            return Ok();

        }
        [HttpGet("generatepdf")]
        public async Task<IActionResult> GeneratePDF(string NameOfFile , int orderId)
        {
            var document = new PdfDocument();
            var product = await _OrderService.GetById(orderId);

            string HtmlContent = @"
    <style>
        body {
            width: 530px;
            height:1123px;
        }
        table {
            border-collapse: collapse;
            width: 100%;
        }
        td {
            border: 1px solid #dddddd;
            text-align: left;
            padding: 8px;
            vertical-align: top;

            font-size: 12px;
            width: 50%;
            
        }

    </style>
</head>
<body>
    <table>
        <tr>
            <td>
                <b>1. Họ tên người gửi:</b>
"+ product.SendName 
     +  @" <br>
                <b>Điện thoại: </b>
        "+ product.SendPhoneNumber
        +"<br><b>Địa chỉ người gửi: </b>"+ product.SendAddress
        +@"
                <br>
                <b>Mã đơn hàng:</b>
"+ product.Code+
               @"
            </td>
            <td>
                <b>2. Họ tên người nhận: </b>
            "+product.ReceiveName
           +"<br><b>Địa chỉ người nhận: </b>" + product.ReceiveAddress+

            @"<br>
                <b>Điện thoại:</b>
            " + product.ReceivePhoneNumber
            +@"
            </td>
        </tr>
        <tr>
            <td>
                <b>3. Loại hàng gửi</b><br>

                <br>
                <b>4. Nội dung giá trị bưu gửi</b><br>
                       
            </td>
            <td>
                <b>9. Cước: </b>
" +product.Cuoc+@"<br>
                a, Cước chính<br>
                b, Phụ phí<br>
                c, Cước GTGT<br>
                d, Tổng cước(gồm VAT)<br>
                e, Thu khác<br>
                <b>f, Tổng thu</b>
            </td>



        </tr>
        <tr>

            <td>
                <b>5. Dịch vụ đặc biệt/Cộng thêm</b>
                <br>
                <br>
                <br>
            </td>

            <td>
                <b>10. Khối lượng: </b>
"+ product.KhoiLuong+ @"kg<br>
                Khôi lượng  thực tế:<br>
                Khối lượng quy đổi:<br>
            </td>

        </tr>
        <tr>
        </tr>
        <tr>
            <td>
                <b>6. Chỉ dẫn của người gửi khi không phát được bưu gửi</b><br>

               
            </td>
            <td>
                <b>11. Thu của người nhận</b><br>
                COD<br>
                Thu khác<br>
                Tổng thu
            </td>

        </tr>
        <tr>

            <td>
                <b>7. Cam kết của người gửi</b><br>

            </td>
<td>
                <b>13. Bưu cục chấp nhận</b>
                <br><small>Chữ kí của GDV nhận</small>
            </td>
            

        </tr>
        <tr>

            <td>
                <b>8. Ngày giờ gửi</b>
<br>
                <b>Chữ kí người gửi</b><br><br>
            </td>
            <td>
                <b>14. Ngày giờ nhận</b><br>
                <br>
                <small style=""text-align: center;"">Người nhận/Người được<br>
                uỷ quyền nhận<br>
                (Ký, ghi rõ họ tên)</small><br><br><br><br>
            </td>
        </tr>
    </table>

</body>
            "; 

            PdfGenerator.AddPdfPages(document, HtmlContent, PageSize.A4);
            byte[]? response = null;
            using (MemoryStream ms = new MemoryStream())
            {
                document.Save(ms);
                response = ms.ToArray();
            }
            string Filename = "Đơn hàng" + NameOfFile + " .pdf";
            return File(response, "application/pdf", Filename);
        }
    }
}
