using MagicPost_ViewModel.Common;
using MagicPost_ViewModel.Diem;
using MagicPost_ViewModel.System.Users;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace MagicPost_ApiIntergration
{
    public class DiemTapKetApiClient : IDiemTapKetApiClient
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _configuration;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public DiemTapKetApiClient(IHttpClientFactory httpClientFactory, IConfiguration configuration, IHttpContextAccessor httpContextAccessor)
        {
            _httpClientFactory = httpClientFactory;
            _configuration = configuration;
            _httpContextAccessor = httpContextAccessor;
        }
        public async Task<ApiResult<PageResult<DiemTapKetVm>>> GetUsersPagings(PagingRequestBase request)
        {
            var client = _httpClientFactory.CreateClient();
            var sessions = _httpContextAccessor.HttpContext.Session.GetString("Token");
            client.BaseAddress = new Uri(_configuration["BaseAddress"]);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", sessions);
            var response = await client.GetAsync($"/api/DiemTapKet/paging?pageIndex=" +
                $"{request.PageIndex}&pageSize={request.PageSize}&BearerToken={sessions}"); // liên kết luôn đến api endpoint của web api luôn
            var body = await response.Content.ReadAsStringAsync();
            var DiemTapKets = JsonConvert.DeserializeObject<ApiResult<PageResult<DiemTapKetVm>>>(body);
            return DiemTapKets;
        }
    }
}
