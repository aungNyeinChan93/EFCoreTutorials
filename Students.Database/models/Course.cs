using System;
using System.Collections.Generic;

namespace Students.Database.models;

public partial class Course
{
    public string DepartmentCode { get; set; } = null!;

    public int CourseNumber { get; set; }

    public string CourseTitle { get; set; } = null!;

    public string CourseDescription { get; set; } = null!;

    public decimal Credits { get; set; }

    public int? MaximumSectionSize { get; set; }

    public virtual ICollection<CourseOffering> CourseOfferings { get; set; } = new List<CourseOffering>();

    public virtual ICollection<DegreeRequirement> DegreeRequirements { get; set; } = new List<DegreeRequirement>();

    public virtual Department DepartmentCodeNavigation { get; set; } = null!;
}
