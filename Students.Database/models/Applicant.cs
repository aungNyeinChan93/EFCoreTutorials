using System;
using System.Collections.Generic;

namespace Students.Database.models;

public partial class Applicant
{
    public int ApplicantId { get; set; }

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

    public DateOnly ApplicationReceivedDate { get; set; }

    public string EntryTerm { get; set; } = null!;

    public string ApplicationType { get; set; } = null!;

    public decimal? Gpa { get; set; }

    public int? SatMathScore { get; set; }

    public int? SatReadingScore { get; set; }

    public int? SatWritingScore { get; set; }

    public int? EssayScore { get; set; }

    public string ApplicationStatus { get; set; } = null!;

    public double? AdmissionPoints { get; set; }

    public virtual Term EntryTermNavigation { get; set; } = null!;
}
