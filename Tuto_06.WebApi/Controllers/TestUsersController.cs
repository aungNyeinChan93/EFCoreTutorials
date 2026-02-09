using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tuto_06.WebApi.Models;

namespace Tuto_06.WebApi.Controllers
{
    [Route("api/[controller]")] 
    [ApiController]
    public class TestUsersController : ControllerBase
    {
        [HttpPost]
        public IActionResult Create([FromBody] TestUser user)
        {
            return Ok(user);
        }
    }
}
