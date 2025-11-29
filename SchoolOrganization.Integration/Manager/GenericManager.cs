using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace SchoolOrganization.Integration.Manager
{
    public class GenericManager<T> where T : class
    {
        protected readonly HttpClient _httpClient;
        protected readonly string _baseUrl;
        protected readonly T _requestBody;

        public GenericManager(HttpClient httpClient, string baseUrl, T requestBody)
        {
            _httpClient = httpClient;
            _baseUrl = baseUrl;
            _requestBody = requestBody;
        }

        public async Task<T> Get()
        {
            var response = await _httpClient.GetFromJsonAsync<T>(_baseUrl);
            return response!;
        }

        public async Task<T> GetById(int id)
        {
            var response = await _httpClient.GetFromJsonAsync<T>($"{_baseUrl}/{id}");
            return response!;
        }

        public async Task<T> Post()
        {
            var response = await _httpClient.PostAsJsonAsync(_baseUrl, _requestBody);
            return await response.Content.ReadFromJsonAsync<T>()!;
        }

        public async Task<T> Put(int id)
        {
            var response = await _httpClient.PutAsJsonAsync($"{_baseUrl}/{id}", _requestBody);
            return await response.Content.ReadFromJsonAsync<T>()!;
        }

        public async Task<T> Patch(int id)
        {
            var request = new HttpRequestMessage(new HttpMethod("PATCH"), $"{_baseUrl}/{id}")
            {
                Content = JsonContent.Create(_requestBody)
            };
            var response = await _httpClient.SendAsync(request);
            return await response.Content.ReadFromJsonAsync<T>()!;
        }
    }
}
