


using Tuto_05.ConsoleApp1.ADO;
using Tuto_05.ConsoleApp1.Daaper;
using Tuto_05.ConsoleApp1.EFCore;

Console.WriteLine("Dapper Test");

BlogDapper blogDapper = new BlogDapper();

//blogDapper.GetBlogs();



BlogAdo blogAdo = new BlogAdo();
//blogAdo.Read();

EFBlogs efBlog = new EFBlogs();
efBlog.Read();
Console.WriteLine(" Success!");
Console.WriteLine("end... ");