using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Students.Database.models;

public partial class AppDbContext : DbContext
{
    public AppDbContext()
    {
    }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Applicant> Applicants { get; set; }

    public virtual DbSet<ClassStanding> ClassStandings { get; set; }

    public virtual DbSet<Course> Courses { get; set; }

    public virtual DbSet<CourseEnrollment> CourseEnrollments { get; set; }

    public virtual DbSet<CourseOffering> CourseOfferings { get; set; }

    public virtual DbSet<Degree> Degrees { get; set; }

    public virtual DbSet<DegreeLevel> DegreeLevels { get; set; }

    public virtual DbSet<DegreeRequirement> DegreeRequirements { get; set; }

    public virtual DbSet<DegreeType> DegreeTypes { get; set; }

    public virtual DbSet<Department> Departments { get; set; }

    public virtual DbSet<Grade> Grades { get; set; }

    public virtual DbSet<Session> Sessions { get; set; }

    public virtual DbSet<Student> Students { get; set; }

    public virtual DbSet<StudentProfile> StudentProfiles { get; set; }

    public virtual DbSet<Term> Terms { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=Students;Integrated Security=True;Persist Security Info=False;Pooling=False;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Applicant>(entity =>
        {
            entity.HasKey(e => e.ApplicantId).HasName("pk_applicants");

            entity.HasIndex(e => e.LastName, "IX_Applicants_LastName");

            entity.Property(e => e.ApplicationStatus)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasDefaultValue("N");
            entity.Property(e => e.ApplicationType)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.City)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.Email)
                .HasMaxLength(80)
                .IsUnicode(false);
            entity.Property(e => e.EntryTerm)
                .HasMaxLength(6)
                .IsUnicode(false);
            entity.Property(e => e.FirstName)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.Gender)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.Gpa).HasColumnType("decimal(3, 2)");
            entity.Property(e => e.LastName)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.MiddleName)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.State)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.StreetAddress)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Telephone)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.ZipCode)
                .HasMaxLength(5)
                .IsUnicode(false);

            entity.HasOne(d => d.EntryTermNavigation).WithMany(p => p.Applicants)
                .HasForeignKey(d => d.EntryTerm)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_applicants_entry_term");
        });

        modelBuilder.Entity<ClassStanding>(entity =>
        {
            entity.HasKey(e => e.ClassStandingCode).HasName("pk_class_standings");

            entity.Property(e => e.ClassStandingCode)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.ClassStandingName)
                .HasMaxLength(25)
                .IsUnicode(false);
            entity.Property(e => e.DegreeLevelCode)
                .HasMaxLength(1)
                .IsUnicode(false);

            entity.HasOne(d => d.DegreeLevelCodeNavigation).WithMany(p => p.ClassStandings)
                .HasForeignKey(d => d.DegreeLevelCode)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_class_stdgs_degree_level_cd");
        });

        modelBuilder.Entity<Course>(entity =>
        {
            entity.HasKey(e => new { e.DepartmentCode, e.CourseNumber }).HasName("pk_courses");

            entity.Property(e => e.DepartmentCode)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.CourseDescription)
                .HasMaxLength(512)
                .IsUnicode(false);
            entity.Property(e => e.CourseTitle)
                .HasMaxLength(64)
                .IsUnicode(false);
            entity.Property(e => e.Credits).HasColumnType("decimal(3, 1)");

            entity.HasOne(d => d.DepartmentCodeNavigation).WithMany(p => p.Courses)
                .HasForeignKey(d => d.DepartmentCode)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Courses_DepartmentCode");
        });

        modelBuilder.Entity<CourseEnrollment>(entity =>
        {
            entity.HasKey(e => e.CourseEnrollmentId).HasName("pk_CourseEnrollments");

            entity.Property(e => e.Grade)
                .HasMaxLength(1)
                .IsUnicode(false);

            entity.HasOne(d => d.CourseOffering).WithMany(p => p.CourseEnrollments)
                .HasForeignKey(d => d.CourseOfferingId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_CourseEnrollments_CourseOfferings");

            entity.HasOne(d => d.GradeNavigation).WithMany(p => p.CourseEnrollments)
                .HasForeignKey(d => d.Grade)
                .HasConstraintName("fk_CourseEnrollments_Grade");

            entity.HasOne(d => d.Student).WithMany(p => p.CourseEnrollments)
                .HasForeignKey(d => d.StudentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_CourseEnrollments_StudentId");
        });

        modelBuilder.Entity<CourseOffering>(entity =>
        {
            entity.HasKey(e => e.CourseOfferingId).HasName("pk_CourseOfferings");

            entity.HasIndex(e => e.TermCode, "IX_CourseOfferings_TermCode");

            entity.Property(e => e.DepartmentCode)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.TermCode)
                .HasMaxLength(6)
                .IsUnicode(false);

            entity.HasOne(d => d.TermCodeNavigation).WithMany(p => p.CourseOfferings)
                .HasForeignKey(d => d.TermCode)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_CourseOfferings_TermCode");

            entity.HasOne(d => d.Course).WithMany(p => p.CourseOfferings)
                .HasForeignKey(d => new { d.DepartmentCode, d.CourseNumber })
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_CourseOfferings_Courses");
        });

        modelBuilder.Entity<Degree>(entity =>
        {
            entity.HasKey(e => e.DegreeId).HasName("pk_degrees");

            entity.Property(e => e.DegreeName)
                .HasMaxLength(64)
                .IsUnicode(false);
            entity.Property(e => e.DegreeTypeCode)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.DepartmentCode)
                .HasMaxLength(2)
                .IsUnicode(false);

            entity.HasOne(d => d.DegreeTypeCodeNavigation).WithMany(p => p.Degrees)
                .HasForeignKey(d => d.DegreeTypeCode)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_degrees_DegreeTypeCode");

            entity.HasOne(d => d.DepartmentCodeNavigation).WithMany(p => p.Degrees)
                .HasForeignKey(d => d.DepartmentCode)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_degrees_DepartmentCode");
        });

        modelBuilder.Entity<DegreeLevel>(entity =>
        {
            entity.HasKey(e => e.DegreeLevelCode).HasName("pk_degree_levels");

            entity.Property(e => e.DegreeLevelCode)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.DegreeLevelName)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        modelBuilder.Entity<DegreeRequirement>(entity =>
        {
            entity.HasKey(e => e.RequirementId).HasName("pk_DegreeRequirements");

            entity.Property(e => e.ClassStandingCode)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.DepartmentCode)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.SessionCode)
                .HasMaxLength(2)
                .IsUnicode(false);

            entity.HasOne(d => d.ClassStandingCodeNavigation).WithMany(p => p.DegreeRequirements)
                .HasForeignKey(d => d.ClassStandingCode)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_DegreeReqirements_ClassStandingCode");

            entity.HasOne(d => d.Degree).WithMany(p => p.DegreeRequirements)
                .HasForeignKey(d => d.DegreeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_DegreeReqirements_DegreeId");

            entity.HasOne(d => d.SessionCodeNavigation).WithMany(p => p.DegreeRequirements)
                .HasForeignKey(d => d.SessionCode)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_DegreeReqirements_SessionCode");

            entity.HasOne(d => d.Course).WithMany(p => p.DegreeRequirements)
                .HasForeignKey(d => new { d.DepartmentCode, d.CourseNumber })
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_DegreeReqirements_Courses");
        });

        modelBuilder.Entity<DegreeType>(entity =>
        {
            entity.HasKey(e => e.DegreeTypeCode).HasName("pk_DegreeTypes");

            entity.Property(e => e.DegreeTypeCode)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.DegreeLevelCode)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.DegreeTypeName)
                .HasMaxLength(25)
                .IsUnicode(false);

            entity.HasOne(d => d.DegreeLevelCodeNavigation).WithMany(p => p.DegreeTypes)
                .HasForeignKey(d => d.DegreeLevelCode)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_degree_types_degree_type_cd");
        });

        modelBuilder.Entity<Department>(entity =>
        {
            entity.HasKey(e => e.DepartmentCode).HasName("pk_departments");

            entity.Property(e => e.DepartmentCode)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.DepartmentName)
                .HasMaxLength(25)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Grade>(entity =>
        {
            entity.HasKey(e => e.Grade1).HasName("pk_grades");

            entity.Property(e => e.Grade1)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("Grade");
            entity.Property(e => e.IncludeInGpa).HasDefaultValue(true);
            entity.Property(e => e.Points).HasColumnType("decimal(2, 1)");
        });

        modelBuilder.Entity<Session>(entity =>
        {
            entity.HasKey(e => e.SessionCode).HasName("pk_sessions");

            entity.Property(e => e.SessionCode)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.SessionName)
                .HasMaxLength(10)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Student>(entity =>
        {
            entity.HasKey(e => e.StudentId).HasName("pk_students");

            entity.Property(e => e.City)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.ClassStandingCode)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.Email)
                .HasMaxLength(80)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.EnrollmentTerm)
                .HasMaxLength(6)
                .IsUnicode(false);
            entity.Property(e => e.FirstName)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.Gender)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.LastName)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.MiddleName)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.State)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.StreetAddress)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.StudentStatus)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.Telephone)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.ZipCode)
                .HasMaxLength(5)
                .IsUnicode(false);

            entity.HasOne(d => d.ClassStandingCodeNavigation).WithMany(p => p.Students)
                .HasForeignKey(d => d.ClassStandingCode)
                .HasConstraintName("fk_Students_ClassStanding");

            entity.HasOne(d => d.DegreePursuedNavigation).WithMany(p => p.Students)
                .HasForeignKey(d => d.DegreePursued)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Students_DegreePursued");

            entity.HasOne(d => d.EnrollmentTermNavigation).WithMany(p => p.Students)
                .HasForeignKey(d => d.EnrollmentTerm)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Students_EnrollmentTerm");
        });

        modelBuilder.Entity<StudentProfile>(entity =>
        {
            entity.HasKey(e => e.StudentId).HasName("PK__StudentP__32C52B99D580B8FD");

            entity.Property(e => e.StudentId).ValueGeneratedNever();
        });

        modelBuilder.Entity<Term>(entity =>
        {
            entity.HasKey(e => e.TermCode).HasName("pk_terms");

            entity.Property(e => e.TermCode)
                .HasMaxLength(6)
                .IsUnicode(false);
            entity.Property(e => e.SessionCode)
                .HasMaxLength(2)
                .IsUnicode(false);

            entity.HasOne(d => d.SessionCodeNavigation).WithMany(p => p.Terms)
                .HasForeignKey(d => d.SessionCode)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Terms_SessionCode");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
