using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using MagicPost_ViewModel.Orders;
using MagicPostUtilities.Constants;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace MagicPost_ApiIntergration
{
    public class TransferApiClient : BaseApiClient, ITransferApiClient
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _configuration;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public TransferApiClient(IHttpClientFactory httpClientFactory,
                  IHttpContextAccessor httpContextAccessor,
                   IConfiguration configuration)
        : base(httpClientFactory, httpContextAccessor, configuration)
        {
            _httpClientFactory = httpClientFactory;
            _configuration = configuration;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<bool> CreateTransfer(int id, TransferCreateRequest request)
        {
            var sessions = _httpContextAccessor.HttpContext.Session.GetString(SystemConstants.AppSettings.Token);

            // var languageId = _httpContextAccessor.HttpContext.Session.GetString(SystemConstants.AppSettings.DefaultLanguageId);

            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration[SystemConstants.AppSettings.BaseAddress]);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", sessions);

            var requestContent = new MultipartFormDataContent();

            requestContent.Add(new StringContent(string.IsNullOrEmpty(id.ToString()) ? "" : id.ToString()), "Code");

            requestContent.Add(new StringContent(request.ToDiemTk.ToString()), "ToDiemTk");

            var response = await client.PutAsync($"/api/transfer/{id}", requestContent);
            return response.IsSuccessStatusCode;
        }
    }
}
