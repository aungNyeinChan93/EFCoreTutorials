using ConsoleApp5.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Tuto_05.ConsoleApp1.Models;

namespace Tuto_05.ConsoleApp1.EFCore
{
    internal class EFBlogs
    {
        public void Read()
        {
            //AppDbContext db = new AppDbContext();
            AppDbContext db = new AppDbContext();
            List<BlogDto> blogs = db.Blog.AsNoTracking().ToList();

            foreach (var blog in blogs)
            {
                Console.WriteLine($"Author Name is {blog.AuthorName}");
            }
        }
    }
}
