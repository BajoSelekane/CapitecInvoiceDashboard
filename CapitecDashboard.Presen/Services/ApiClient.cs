using System.Net.Http.Json;
using Microsoft.AspNetCore.Http;

namespace CapitecDashboard.Presen.Services
{
    public class ApiClient
    {
        private readonly HttpClient httpClient;
        private readonly IHttpContextAccessor httpContextAccessor;

        public ApiClient(HttpClient httpClient, IHttpContextAccessor httpContextAccessor)
        {
            this.httpClient = httpClient;
            this.httpContextAccessor = httpContextAccessor;
        }

        public async Task<T?> PostAsync<T>(string url, object payload)
        {
            AttachBearer();
            var response = await httpClient.PostAsJsonAsync(url, payload);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<T>();
        }

        public async Task<T?> GetAsync<T>(string url)
        {
            AttachBearer();
            return await httpClient.GetFromJsonAsync<T>(url);
        }

        private void AttachBearer()
        {
            var token = httpContextAccessor.HttpContext?.Session?.GetString("jwt");
            if (!string.IsNullOrEmpty(token))
            {
                if (httpClient.DefaultRequestHeaders.Authorization == null || httpClient.DefaultRequestHeaders.Authorization.Parameter != token)
                {
                    httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
                }
            }
        }
    }
}


