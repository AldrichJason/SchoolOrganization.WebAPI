using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolOrganization.Integration.Entities;
using SchoolOrganization.Integration.Services;

namespace SchoolOrganization.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseUrl = "https://reqres.in/api/users";

        public UserController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            UserService userService = new UserService(_httpClient, _baseUrl);
            var result = await userService.GetAll();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            UserService userService = new UserService(_httpClient, _baseUrl);
            var result = await userService.GetById(id);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> PostUser(User user)
        {
            UserService userService = new UserService(_httpClient, _baseUrl);
            var result = await userService.PostUser(user);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser(int id, User user)
        {
            UserService userService = new UserService(_httpClient, _baseUrl);
            var result = await userService.PutUser(id, user);
            return Ok(result);
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> PatchUser(int id, User user)
        {
            UserService userService = new UserService(_httpClient, _baseUrl);
            var result = await userService.PatchUser(id, user);
            return Ok(result);
        }
    }
}
