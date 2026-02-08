using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

    [Table("Tbl_blogs")]
    internal class BlogDto
    {
        [Key]
        [Column("BLogId")]
        public int BlogId { get; set; }

        [Column("Title")]
        public string Title { get; set; } = string.Empty;

        [Column("Description")]
        public string Description { get; set; } = null!;

        [Column("AuthorName")]
        public string AuthorName { get; set; } = null!;

        [Column("DeleteFlag")]
        public bool DeleteFlag { get; set; } = false;
    }
}
