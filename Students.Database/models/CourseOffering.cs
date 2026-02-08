using System;
using System.Collections.Generic;

namespace Students.Database.models;

public partial class CourseOffering
{
    public int CourseOfferingId { get; set; }

    public string DepartmentCode { get; set; } = null!;

    public int CourseNumber { get; set; }

    public string TermCode { get; set; } = null!;

    public int Section { get; set; }

    public int Capacity { get; set; }

    public virtual Course Course { get; set; } = null!;

    public virtual ICollection<CourseEnrollment> CourseEnrollments { get; set; } = new List<CourseEnrollment>();

    public virtual Term TermCodeNavigation { get; set; } = null!;
}
