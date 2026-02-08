using System;
using System.Collections.Generic;

namespace Students.Database.models;

public partial class Grade
{
    public string Grade1 { get; set; } = null!;

    public decimal? Points { get; set; }

    public bool IncludeInGpa { get; set; }

    public virtual ICollection<CourseEnrollment> CourseEnrollments { get; set; } = new List<CourseEnrollment>();
}
