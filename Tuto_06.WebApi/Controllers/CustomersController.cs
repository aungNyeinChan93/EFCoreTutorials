//using Database.Models;
using Database2.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Tuto_06.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {

        private readonly AppDaContext _db = new AppDaContext();
        //private readonly AppDbContext _db = new AppDbContext();
        [HttpGet]
        public IActionResult GetAll()
        {
            var customers = this._db.Customers.AsNoTracking().ToList<Customer>();
            if (customers.Count <=0)
            {
                return NotFound();
            }
            return Ok(new { customers,messgae="success"});
        }

        //[HttpGet("/api/[controller]/{id}")]
        [HttpGet]
        [Route("/api/[controller]/{id}")]
        public IActionResult GetById([FromRoute]string? id = null)
        {
            Customer? customer = this._db.Customers.AsNoTracking().Where(c => c.CustomerId.Equals(id)).FirstOrDefault();

            if(customer is null)
            {
                return NotFound($"Customer {id} is not found");
            }
            return Ok(new {customer });
        }

        [HttpPost]
        [Route("/api/[controller]")]
        public IActionResult Create([FromBody]Customer customer)
        {
            this._db.Add(customer);
            int result = this._db.SaveChanges();
            if(result <= 0)
            {
                return BadRequest("Create fail");
            }
            return Created();
        }

        [HttpGet]
        [Route("/api/[controller]/tests")]
        public IActionResult Test([FromHeader]string name, [FromQuery]int? id, [FromForm] int? age, [FromHeader]string? Authorization)
        {
            var token = Authorization?.ToString().Split(" ")[1] ?? "no token ";
            return Ok(new{ name , id ,age ,token });
        }


    }
}
