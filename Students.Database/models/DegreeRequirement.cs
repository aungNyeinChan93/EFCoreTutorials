using System;
using System.Collections.Generic;

namespace Students.Database.models;

public partial class DegreeRequirement
{
    public int RequirementId { get; set; }

    public int DegreeId { get; set; }

    public string ClassStandingCode { get; set; } = null!;

    public string SessionCode { get; set; } = null!;

    public string DepartmentCode { get; set; } = null!;

    public int CourseNumber { get; set; }

    public virtual ClassStanding ClassStandingCodeNavigation { get; set; } = null!;

    public virtual Course Course { get; set; } = null!;

    public virtual Degree Degree { get; set; } = null!;

    public virtual Session SessionCodeNavigation { get; set; } = null!;
}
