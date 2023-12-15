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
    public class DiemGiaoDichApiClient : IDiemGiaoDichApiClient
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _configuration;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public DiemGiaoDichApiClient(IHttpClientFactory httpClientFactory, IConfiguration configuration, IHttpContextAccessor httpContextAccessor)
        {
            _httpClientFactory = httpClientFactory;
            _configuration = configuration;
            _httpContextAccessor = httpContextAccessor;
        }
        public async Task<ApiResult<PageResult<DiemGiaoDichVm>>> GetUsersPagings(PagingRequestBase request, int DiemTapKetId)
        {
            var client = _httpClientFactory.CreateClient();
            var sessions = _httpContextAccessor.HttpContext.Session.GetString("Token");
            client.BaseAddress = new Uri(_configuration["BaseAddress"]);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", sessions);
            var response = await client.GetAsync($"/api/DiemGiaoDich/paging/{DiemTapKetId}?pageIndex=" +
                $"{request.PageIndex}&pageSize={request.PageSize}&BearerToken={sessions}"); // liên kết luôn đến api endpoint của web api luôn
            var body = await response.Content.ReadAsStringAsync();
            var DiemGiaoDichs = JsonConvert.DeserializeObject<ApiResult<PageResult<DiemGiaoDichVm>>>(body);
            return DiemGiaoDichs;
        }
        public async Task<ApiResult<PageResult<DiemGiaoDichVm>>> GetUsersPagingsAll(PagingRequestBase request)
        {
            var client = _httpClientFactory.CreateClient();
            var sessions = _httpContextAccessor.HttpContext.Session.GetString("Token");
            client.BaseAddress = new Uri(_configuration["BaseAddress"]);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", sessions);
            var response = await client.GetAsync($"/api/DiemGiaoDich/paging?pageIndex=" +
                $"{request.PageIndex}&pageSize={request.PageSize}&BearerToken={sessions}"); // liên kết luôn đến api endpoint của web api luôn
            var body = await response.Content.ReadAsStringAsync();
            var DiemGiaoDichs = JsonConvert.DeserializeObject<ApiResult<PageResult<DiemGiaoDichVm>>>(body);
            return DiemGiaoDichs;
        }
    }
}
