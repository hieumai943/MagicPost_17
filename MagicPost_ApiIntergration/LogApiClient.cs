

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
    public class LogApiClient : BaseApiClient, ILogApiClient
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _configuration;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public LogApiClient(IHttpClientFactory httpClientFactory,
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
                $"/api/Log/paging?keyword={request.Keyword}&OrderStatusId={request.OrderStatusId}&PageIndex={request.PageIndex}" +
                $"&pageSize={request.PageSize}");


            return data;
        }
        public async Task<PageResult<OrderVm>> GetPagingGui(GetManageOrderPagingRequest request)
        {
            var data = await GetAsync<PageResult<OrderVm>>(
                $"/api/order/paging/?keyword={request.Keyword}&PageIndex={request.PageIndex}" +
                $"&pageSize={request.PageSize}");
            return data;
        }
        public async Task<PageResult<OrderVm>> GetPagingNhan(GetManageOrderPagingRequest request)
        {
            throw new NotImplementedException();
        }
       

    }
}
