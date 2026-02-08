using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Tuto_05.ConsoleApp1.Models;

namespace Tuto_05.ConsoleApp1.Daaper
{
    public class BlogDapper
    {
        private readonly string _connectionStr = $"Data Source=.;Initial Catalog=KSLH_01;Integrated Security=True;Persist Security Info=False;Pooling=False;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=True;Application Name=\"SQL Server Management Studio\"";

        public void GetBlogs()
        {
            using (IDbConnection db = new SqlConnection(this._connectionStr))
            {
                string query = @"SELECT [BlogId]
                      ,[Title]
                      ,[Description]
                      ,[AuthorName]
                      ,[DeleteFlag]
                  FROM [dbo].[Tbl_Blogs] WHERE DeleteFlag = 1";
                var blogs = db.Query<BlogModels>(query).ToList();

                foreach (var blog in blogs)
                {
                    Console.WriteLine($"Author Name is {blog.AuthorName} and Blog Title is {blog?.Title}");
                }


            }
        }
    }
}
