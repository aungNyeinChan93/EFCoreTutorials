//using Database.Models;
using Database2.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Tuto_06.WebApi.Repos;

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

        [HttpPut("{customerName}")]
        //[Route("/api/[controller]/update/{customerName}")]
        public IActionResult Update([FromRoute] string customerName, [FromBody] Customer customer)
        {
            var oldCustomer = this._db.Customers.AsNoTracking().Where(c => c.CustomerId.ToString() == customerName.ToString()).FirstOrDefault();
            if (oldCustomer is null)
            {
                return BadRequest("Customer not Found!");
            }

            oldCustomer.CompanyName = customer.CompanyName;

            this._db.Entry(oldCustomer).State = EntityState.Modified;
            int res = this._db.SaveChanges();
            if (res <= 0)
            {
                return BadRequest("Customer update fail");
            }
            return Ok(customerName);
        }

        [HttpDelete("{customerName}")]
        public IActionResult Delete([FromRoute] string customerName)
        {
            var customer = this._db.Customers.AsNoTracking().Where(c => c.CustomerId.ToString() == customerName).FirstOrDefault();

            if(customer is null)
            {
                return BadRequest("customer not found!");
            }

            this._db.Entry(customer).State = EntityState.Deleted;
            int res = this._db.SaveChanges();
            return res >= 1 ? Ok(customerName) : BadRequest();
        }

        [HttpGet]
        [Route("/api/[controller]/check/{name}")]
        public IActionResult Check([FromRoute] string name)
        {
            bool success = CustomerRepo.IsExist(name);
            return success ? Ok(new{message= "is exist!"}) : BadRequest();
        }
    }
}
