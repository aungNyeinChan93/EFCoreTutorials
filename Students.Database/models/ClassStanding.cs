using System;
using System.Collections.Generic;

namespace Students.Database.models;

public partial class ClassStanding
{
    public string ClassStandingCode { get; set; } = null!;

    public string ClassStandingName { get; set; } = null!;

    public string DegreeLevelCode { get; set; } = null!;

    public int RequiredCredits { get; set; }

    public virtual DegreeLevel DegreeLevelCodeNavigation { get; set; } = null!;

    public virtual ICollection<DegreeRequirement> DegreeRequirements { get; set; } = new List<DegreeRequirement>();

    public virtual ICollection<Student> Students { get; set; } = new List<Student>();
}
