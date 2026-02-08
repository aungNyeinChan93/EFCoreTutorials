using System;
using System.Collections.Generic;

namespace Students.Database.models;

public partial class DegreeType
{
    public string DegreeTypeCode { get; set; } = null!;

    public string DegreeTypeName { get; set; } = null!;

    public string DegreeLevelCode { get; set; } = null!;

    public virtual DegreeLevel DegreeLevelCodeNavigation { get; set; } = null!;

    public virtual ICollection<Degree> Degrees { get; set; } = new List<Degree>();
}
