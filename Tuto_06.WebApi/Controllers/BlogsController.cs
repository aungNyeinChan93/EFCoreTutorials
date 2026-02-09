using Database.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Tuto_06.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogsController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAll()
        {
            AppDbContext db = new AppDbContext();
            //var blogs = db.
            return Ok();
        }
    }
}
