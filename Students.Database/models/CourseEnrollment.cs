using System;
using System.Collections.Generic;

namespace Students.Database.models;

public partial class CourseEnrollment
{
    public int CourseEnrollmentId { get; set; }

    public int CourseOfferingId { get; set; }

    public int StudentId { get; set; }

    public string? Grade { get; set; }

    public virtual CourseOffering CourseOffering { get; set; } = null!;

    public virtual Grade? GradeNavigation { get; set; }

    public virtual Student Student { get; set; } = null!;
}
