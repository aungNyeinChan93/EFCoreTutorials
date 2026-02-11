using KSLT_Database.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tuto_07.WebApi.Filters.ActionFilters;
using Microsoft.EntityFrameworkCore;
namespace Tuto_07.WebApi.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class BlogsController : ControllerBase
    {
        private readonly AppDbContext _db = new ();

        [HttpGet]
        public IActionResult GetAllBlogs()
        {
            
            var blogs = this._db.TblBlogs.ToList<TblBlog>();

            return Ok(new { blogs });
        }

        [HttpGet("{id:int}")]
        [GetBlogActionFilter]
        public IActionResult GetBlog([FromRoute]int? id)
        {
            var blog = _db.TblBlogs.FirstOrDefault(b=>b.BlogId == id);
            return Ok(blog);
        }

        [HttpPost]
        [CreateBlogActionFilter]
        public IActionResult Create([FromBody] TblBlog blog)
        {
            var b = _db.TblBlogs.FirstOrDefault(b => b.BlogId == blog.BlogId);
            if (b is not null) return BadRequest("Blog Is already exist");

            _db.TblBlogs.Add(blog);
            int res = _db.SaveChanges();
            return res <= 0 ? BadRequest() : Ok(new { blog });
        }

        [HttpPut("{id}")]
        [UpdateBlogActionFilter]
        public IActionResult Update([FromRoute]int? id,TblBlog blog)
        {
            var b = _db.TblBlogs.FirstOrDefault(b => b.BlogId == id);
            if (b is null) return BadRequest("Blog Not Found");
            b.Title = blog.Title;
            b.Description = blog.Description;
            b.AuthorName = blog.AuthorName;
            _db.Entry(b).State = EntityState.Modified;
            int result = _db.SaveChanges();
            return result <=0 ? BadRequest() : Ok(blog);
        }

        [HttpDelete("{id:int}")]
        public IActionResult Delete([FromRoute]int? id)
        {
            var blog = _db.TblBlogs.FirstOrDefault(b => b.BlogId == id);
            if (blog is null) return BadRequest();
            blog.DeleteFlag = true;
            _db.Entry(blog).State = EntityState.Modified;
            var result = _db.SaveChanges();
            return result > 0? Ok($"Blog {id} was successfully deleted!"): BadRequest();    

        }
    }
}
