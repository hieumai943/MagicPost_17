

using MagicPost_ViewModel.Common;
using System.Net.Http.Headers;
using System.Net.Http;
using Newtonsoft.Json;
using MagicPost_ViewModel.System.Users;
using System.Text;
using shopCommerce_ApiIntergration;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Http;
using MagicPost_ApiIntergration;
using MagicPost_ViewModel.Orders;
using MagicPostUtilities.Constants;

namespace shopCommerce_ApiIntergration
{
	public class OrderApiClient : BaseApiClient, IOrderApiClient
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _configuration;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public OrderApiClient(IHttpClientFactory httpClientFactory,
                  IHttpContextAccessor httpContextAccessor,
                   IConfiguration configuration
                 )
        : base(httpClientFactory, httpContextAccessor, configuration)
        {
            _httpClientFactory = httpClientFactory;
            _configuration = configuration;
            _httpContextAccessor = httpContextAccessor;
        }


        public async Task<PageResult<OrderVm>> GetPagings(GetManageOrderPagingRequest request)
        {
            var data = await GetAsync<PageResult<OrderVm>>(
                $"/api/order/paging?keyword={request.Keyword}&PageIndex={request.PageIndex}" +
                $"&pageSize={request.PageSize}");
               

            return data;
        }
        public async Task<PageResult<OrderVm>> GetPagingDiemGiaoDich(GetManageOrderPagingRequest request, int DiemGiaoDichId)
        {
            var data = await GetAsync<PageResult<OrderVm>>(
                $"/api/order/paging/{DiemGiaoDichId}?keyword={request.Keyword}&PageIndex={request.PageIndex}" +
                $"&pageSize={request.PageSize}");


            return data;
        }
        public async Task<OrderVm> GetById(int id, string languageId)
        {
            var data = await GetAsync<OrderVm>($"/api/product/{id}/{languageId}");

            return data;
        }
        public async Task<byte[]> GetPdf(string nameOfFile)
        {
            var sessions = _httpContextAccessor.HttpContext.Session.GetString("Token");

            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration["BaseAddress"]);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", sessions);
            var response = await client.GetAsync($"/api/order/generatepdf?NameOfFile={nameOfFile}");

            if (response.IsSuccessStatusCode)
            {
                var fileBytes = await response.Content.ReadAsByteArrayAsync();
                return fileBytes;
            }

            return null;
        }
        public async Task<bool> CreateOrder(OrderCreateRequest request)
        {
            var sessions = _httpContextAccessor.HttpContext.Session.GetString(SystemConstants.AppSettings.Token);

            // var languageId = _httpContextAccessor.HttpContext.Session.GetString(SystemConstants.AppSettings.DefaultLanguageId);

            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration[SystemConstants.AppSettings.BaseAddress]);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", sessions);

            var requestContent = new MultipartFormDataContent();

            requestContent.Add(new StringContent(string.IsNullOrEmpty(request.Code) ? "" : request.Code.ToString()), "Code");

            requestContent.Add(new StringContent(request.OrderDate.ToString()), "orderDate");
            requestContent.Add(new StringContent(request.SendName.ToString()), "sendName");
            requestContent.Add(new StringContent(request.Cuoc.ToString()), "Cuoc");
            requestContent.Add(new StringContent(request.KhoiLuong.ToString()), "KhoiLuong");

            requestContent.Add(new StringContent(request.ReceiveName.ToString()), "ReceiveName");

            requestContent.Add(new StringContent(string.IsNullOrEmpty(request.SendAddress) ? "" : request.SendAddress.ToString()), "SendAddress");
            requestContent.Add(new StringContent(string.IsNullOrEmpty(request.ReceiveAddress) ? "" : request.ReceiveAddress.ToString()), "ReceiveAddress");

            requestContent.Add(new StringContent(string.IsNullOrEmpty(request.SendPhoneNumber) ? "" : request.SendPhoneNumber.ToString()), "SendPhoneNumber");
            requestContent.Add(new StringContent(string.IsNullOrEmpty(request.ReceivePhoneNumber) ? "" : request.ReceivePhoneNumber.ToString()), "ReceivePhoneNumber");
            

            var response = await client.PostAsync($"/api/order/", requestContent);
            return response.IsSuccessStatusCode;
        }
    }
}
