using System;
using System.Collections.Generic;

namespace Students.Database.models;

public partial class Student
{
    public int StudentId { get; set; }

    public string FirstName { get; set; } = null!;

    public string MiddleName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string Gender { get; set; } = null!;

    public string StreetAddress { get; set; } = null!;

    public string City { get; set; } = null!;

    public string State { get; set; } = null!;

    public string ZipCode { get; set; } = null!;

    public string Telephone { get; set; } = null!;

    public string Email { get; set; } = null!;

    public DateOnly DateOfBirth { get; set; }

    public int DegreePursued { get; set; }

    public string? ClassStandingCode { get; set; }

    public string StudentStatus { get; set; } = null!;

    public string EnrollmentTerm { get; set; } = null!;

    public virtual ClassStanding? ClassStandingCodeNavigation { get; set; }

    public virtual ICollection<CourseEnrollment> CourseEnrollments { get; set; } = new List<CourseEnrollment>();

    public virtual Degree DegreePursuedNavigation { get; set; } = null!;

    public virtual Term EnrollmentTermNavigation { get; set; } = null!;
}
