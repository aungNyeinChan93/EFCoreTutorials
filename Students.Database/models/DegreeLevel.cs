using System;
using System.Collections.Generic;

namespace Students.Database.models;

public partial class DegreeLevel
{
    public string DegreeLevelCode { get; set; } = null!;

    public string DegreeLevelName { get; set; } = null!;

    public virtual ICollection<ClassStanding> ClassStandings { get; set; } = new List<ClassStanding>();

    public virtual ICollection<DegreeType> DegreeTypes { get; set; } = new List<DegreeType>();
}
