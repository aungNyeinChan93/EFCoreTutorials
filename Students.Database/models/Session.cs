using System;
using System.Collections.Generic;

namespace Students.Database.models;

public partial class Session
{
    public string SessionCode { get; set; } = null!;

    public string SessionName { get; set; } = null!;

    public virtual ICollection<DegreeRequirement> DegreeRequirements { get; set; } = new List<DegreeRequirement>();

    public virtual ICollection<Term> Terms { get; set; } = new List<Term>();
}
