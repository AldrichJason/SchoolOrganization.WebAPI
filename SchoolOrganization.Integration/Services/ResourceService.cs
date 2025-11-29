using SchoolOrganization.Integration.Entities;
using SchoolOrganization.Integration.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace SchoolOrganization.Integration.Services
{
    public class ResourceService
    {
        protected readonly HttpClient _httpClient;
        protected readonly string _baseUrl;

        public ResourceService(HttpClient httpClient, string baseUrl)
        {
            _httpClient = httpClient;
            _baseUrl = baseUrl;
        }

        public async Task<List<ResourceData>> GetAll()
        {
            ResourceManager resourceManager = new ResourceManager(_httpClient, _baseUrl, null);
            var result = await resourceManager.Get();
            return result?.Data ?? new List<ResourceData>();
        }

        public async Task<ResourceData> GetById(int id)
        {
            var response = await _httpClient.GetFromJsonAsync<Dictionary<string, ResourceData>>($"{_baseUrl}/{id}");
            response.TryGetValue("data", out var user);
            return user;
        }

        public async Task<Resource> PostResource(Resource resource)
        {
            ResourceManager resourceManager = new ResourceManager(_httpClient, _baseUrl, resource);
            return await resourceManager.Post();
        }

        public async Task<Resource> PutResource(int id, Resource resource)
        {
            ResourceManager resourceManager = new ResourceManager(_httpClient, _baseUrl, resource);
            return await resourceManager.Put(id);
        }

        public async Task<Resource> PatchResource(int id, Resource resource)
        {
            ResourceManager resourceManager = new ResourceManager(_httpClient, _baseUrl, resource);
            return await resourceManager.Patch(id);
        }
    }
}
