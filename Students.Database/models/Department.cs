using System;
using System.Collections.Generic;

namespace Students.Database.models;

public partial class Department
{
    public string DepartmentCode { get; set; } = null!;

    public string DepartmentName { get; set; } = null!;

    public virtual ICollection<Course> Courses { get; set; } = new List<Course>();

    public virtual ICollection<Degree> Degrees { get; set; } = new List<Degree>();
}
