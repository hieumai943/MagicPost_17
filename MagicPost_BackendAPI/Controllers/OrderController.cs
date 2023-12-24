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
        public async Task<IActionResult> GeneratePDF(string NameOfFile)
        {
            var document = new PdfDocument();
            string HtmlContent = @"
           <style>
        body {
            width: 530px;
         
        }
        table {
            border-collapse: collapse;
            width: 100%;
        }
        th, td {
            border: 1px solid #dddddd;
            text-align: left;
            padding: 8px;
            vertical-align: top;
            
        }
    </style>
          <body>

    <table>
        <tr>
            <td>
                <b>1. Họ tên địa chỉ người gửi</b>
                <br>
                <br>
                <br>

                <b>Điện thoại</b>
                <br>
                <b>Mã khách hàng:</b>
                <b style='margin-left: 300px;'>Mã bưu chính:</b>
            </td>
            <td colspan='2'>
                <b>2. Họ tên địa chỉ người nhận</b><br><br><br>
                <b>Mã ĐH:</b><br>
                <b>Điện thoại:</b>
                <b style='margin-left: 300px;'>Mã bưu chính:</b>
            </td>
        </tr>
        <tr>
            <td>
                <b>3. Loại hàng gửi</b><br>
                    <input type='checkbox' style='margin-left: 50px;'>Tài liệu
                    <input type='checkbox' style='margin-left: 250px;'>Hàng hoá
                <br>
                <b>4. Nội dung giá trị bưu gửi</b>
                <table>
                    <tr>
                        <th>
                            Nội dung
                        </th>
                        <th>Số lượng</th>
                        <th>Trị giá</th>
                        <th>Giấy tờ đính kèm</th>
                    </tr>
                    <tr>
                        <td>
                            Tổng
                        </td>
                        <td></td>
                        <td></td>
                        <td></td>
                    </tr>
                </table>
            </td>
            <td>
                <b>9. Cước</b><br>
                a, Cước chính<br>
                b, Phụ phí<br>
                c, Cước GTGT<br>
                d, Tổng cước(gồm VAT)<br>
                e, Thu khác<br>
                <b>f, Tổng thu</b>
            </td>
            <td>
                <b>10. Khối lượng</b><br>
                Khôi lượng  thực tế:<br>
                Khối lượng quy đổi:<br>
            </td>


        </tr>
        <tr>
            <td rowspan='2'>
                <b>5. Dịch vụ đặc biệt/Cộng thêm</b>
                <br>
                <br>
                <br>
            </td>
            <td >
                <b>12. Chú dẫn nghiệp vụ</b>
            </td>

        </tr>
        <tr>
        </tr>
        <tr>
            <td>
                <b>6. Chỉ dẫn của người gửi khi không phát được bưu gửi</b><br>
                <input type='checkbox'>Chuyển hoàn ngay
                <input type='checkbox' style='margin-left: 40px;'>Gọi điện cho người gửi/BC gửi
                <input type='checkbox' style='margin-left: 40px;'>Huỷ<br>
                <input type='checkbox'>Chuyển hoàn trước ngày
                <input type='checkbox' style='margin-left: 40px;'>Chuyển hoàn khi hết thời gian lưu trữ
            </td>
            <td rowspan=''>
                <b>11. Thu của người nhận</b><br>
                COD<br>
                Thu khác<br>
                Tổng thu
            </td>

        </tr>
        <tr>
            <td rowspan='3'>
                <b>7. Cam kết của người gửi</b><br>
                <br>
                <b>8. Ngày giờ gửi</b>
                <b style='margin-left: 250px;'>Chữ kí người gửi</b><br><br><br>

            </td>
            <td rowspan='2'>
                <b>13. Bưu cục chấp nhận</b>
                <br><small style='margin-left: 50px;'>Chữ kí của GDV nhận</small>
            </td>

        </tr>
        <tr>
            <td rowspan='2'>
                <b>14. Ngày giờ nhận</b><br>
                &nbsp;&nbsp;&nbsp;h&nbsp;&nbsp;&nbsp;/&nbsp;&nbsp;&nbsp;/&nbsp;&nbsp;&nbsp;/20
                <br>
                <small style='text-align: center;'>Người nhận/Người được<br>
                uỷ quyền nhận<br>
                (Ký, ghi rõ họ tên)</small><br><br><br><br>
            </td>
       

        </tr>
    </table>

</body>
            "; ;

            PdfGenerator.AddPdfPages(document, HtmlContent, PageSize.A4);
            byte[]? response = null;
            using (MemoryStream ms = new MemoryStream())
            {
                document.Save(ms);
                response = ms.ToArray();
            }
            string Filename = "Đơn hàng" + NameOfFile + ".pdf";
            return File(response, "application/pdf", Filename);
        }
    }
}
