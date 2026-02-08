


using Tuto_05.ConsoleApp1.ADO;
using Tuto_05.ConsoleApp1.Daaper;

Console.WriteLine("Dapper Test");

BlogDapper blogDapper = new BlogDapper();

//blogDapper.GetBlogs();



BlogAdo blogAdo = new BlogAdo();
blogAdo.Read();
Console.WriteLine("BlogAdo Success!");
Console.WriteLine("end... ");