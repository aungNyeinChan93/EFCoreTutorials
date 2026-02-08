using System;
using System.Collections.Generic;

namespace Students.Database.models;

public partial class Degree
{
    public int DegreeId { get; set; }

    public string DepartmentCode { get; set; } = null!;

    public string DegreeTypeCode { get; set; } = null!;

    public string DegreeName { get; set; } = null!;

    public virtual ICollection<DegreeRequirement> DegreeRequirements { get; set; } = new List<DegreeRequirement>();

    public virtual DegreeType DegreeTypeCodeNavigation { get; set; } = null!;

    public virtual Department DepartmentCodeNavigation { get; set; } = null!;

    public virtual ICollection<Student> Students { get; set; } = new List<Student>();
}
