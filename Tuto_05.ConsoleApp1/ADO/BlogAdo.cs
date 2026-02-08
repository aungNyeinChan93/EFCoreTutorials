using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace Tuto_05.ConsoleApp1.ADO
{
    internal class BlogAdo
    {
        private readonly string _connectionStr = $"Data Source=.;Initial Catalog=KSLH_01;Integrated Security=True;Persist Security Info=False;Pooling=False;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=True;Application Name=\"SQL Server Management Studio\"";

        public void Read()
        {
            SqlConnection connection = new SqlConnection(this._connectionStr);


            connection.Open();

            string selectQuery = @"
                                SELECT [BlogId]
                                      ,[Title]
                                      ,[Description]
                                      ,[AuthorName]
                                      ,[DeleteFlag]
                                  FROM [dbo].[Tbl_Blogs] 
                                  where Tbl_Blogs.DeleteFlag = 0";

            SqlCommand cmd = new SqlCommand(selectQuery, connection);
            DataTable dt = new DataTable();

            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            adapter.Fill(dt);

            foreach (DataRow blog in dt.Rows)
            {
                Console.WriteLine($"Blog Desc = {blog["Description"]}");
            }


            connection.Close();
        }
    }
}
