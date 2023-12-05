

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

namespace shopCommerce_ApiIntergration
{
	public class OrderApiClient : BaseApiClient, IOrderApiClient
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _configuration;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public OrderApiClient(IHttpClientFactory httpClientFactory,
                  IHttpContextAccessor httpContextAccessor,
                   IConfiguration configuration)
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

       
        public async Task<OrderVm> GetById(int id, string languageId)
        {
            var data = await GetAsync<OrderVm>($"/api/product/{id}/{languageId}");

            return data;
        }
       
    }
}
