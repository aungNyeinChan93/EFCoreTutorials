using System;
using System.Collections.Generic;

namespace Students.Database.models;

public partial class Term
{
    public string TermCode { get; set; } = null!;

    public string SessionCode { get; set; } = null!;

    public int Year { get; set; }

    public virtual ICollection<Applicant> Applicants { get; set; } = new List<Applicant>();

    public virtual ICollection<CourseOffering> CourseOfferings { get; set; } = new List<CourseOffering>();

    public virtual Session SessionCodeNavigation { get; set; } = null!;

    public virtual ICollection<Student> Students { get; set; } = new List<Student>();
}
