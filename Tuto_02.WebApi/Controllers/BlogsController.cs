using Database.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Tuto_02.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogsController : ControllerBase
    {

        [HttpGet]
        public IActionResult GetAllBlogs()
        {
            AppDbContext db = new AppDbContext();
            var category = db.Categories.FirstOrDefault();
            return Ok(new {category});
        }
    }
}
