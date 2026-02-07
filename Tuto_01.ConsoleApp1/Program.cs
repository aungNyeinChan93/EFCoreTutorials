using Database.Models;
using Microsoft.EntityFrameworkCore;

Console.WriteLine("Database first with microServices");

AppDbContext db = new AppDbContext();


var categories = db.Categories.AsNoTracking().ToList();

if(categories is null)
{
    Console.WriteLine("Categories list is empty");
    return;
}

foreach (var category in categories)
{
    Console.WriteLine($"category name is {category.CategoryName} \n");
}