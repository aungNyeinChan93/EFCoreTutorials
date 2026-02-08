

using Database.Models;
using Microsoft.EntityFrameworkCore;

Console.WriteLine("This is Database First!");


AppDbContext db = new AppDbContext();

var customers = db.Customers.AsNoTracking().ToList();

foreach (var customer  in customers)
{
    Console.WriteLine($"Company Name is {customer.CompanyName} and Company address {customer.Address}");
}