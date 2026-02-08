using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Tuto_05.ConsoleApp1.Models
{
    //[Table("")]
    internal class BlogModels
    {
        public int BlogId { get; set; }

        public string Title { get; set; } = string.Empty;

        public string Description { get; set; } = null!;

        public string AuthorName { get; set; } = null!;

        public int DeleteFlag { get; set; } = 1;
    }
}
