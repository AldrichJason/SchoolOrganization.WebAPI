using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolOrganization.Integration.Entities;
using SchoolOrganization.Integration.Services;

namespace SchoolOrganization.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResourceController : ControllerBase
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseUrl = "https://reqres.in/api/unknown";

        public ResourceController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            ResourceService resourceService = new ResourceService(_httpClient, _baseUrl);
            var result = await resourceService.GetAll();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            ResourceService resourceService = new ResourceService(_httpClient, _baseUrl);
            var result = await resourceService.GetById(id);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> PostResource(Resource resource)
        {
            ResourceService resourceService = new ResourceService(_httpClient, _baseUrl);
            var result = await resourceService.PostResource(resource);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutResource(int id, Resource resource)
        {
            ResourceService resourceService = new ResourceService(_httpClient, _baseUrl);
            var result = await resourceService.PutResource(id, resource);
            return Ok(result);
        }


        [HttpPatch("{id}")]
        public async Task<IActionResult> PatchResource(int id, Resource resource)
        {
            ResourceService resourceService = new ResourceService(_httpClient, _baseUrl);
            var result = await resourceService.PatchResource(id, resource);
            return Ok(result);
        }
    }
}
