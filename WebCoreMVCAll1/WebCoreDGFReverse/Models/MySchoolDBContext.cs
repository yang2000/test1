using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WebCoreDGFReverse.Models
{
    public partial class MySchoolDBContext : DbContext
    {
        public MySchoolDBContext()
        {
        }

        public MySchoolDBContext(DbContextOptions<MySchoolDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Courses> Courses { get; set; }
        public virtual DbSet<Grades> Grades { get; set; }
        public virtual DbSet<MigrationHistory> MigrationHistory { get; set; }
        public virtual DbSet<StudentAddresses> StudentAddresses { get; set; }
        public virtual DbSet<StudentCourses> StudentCourses { get; set; }
        public virtual DbSet<Students> Students { get; set; }
        public virtual DbSet<TeacherInfo> TeacherInfo { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=home1;Database=MySchoolDB;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Courses>(entity =>
            {
                entity.HasKey(e => e.CourseId);
            });

            modelBuilder.Entity<Grades>(entity =>
            {
                entity.HasKey(e => e.GradeId);
            });

            modelBuilder.Entity<MigrationHistory>(entity =>
            {
                entity.HasKey(e => new { e.MigrationId, e.ContextKey });

                entity.ToTable("__MigrationHistory");

                entity.Property(e => e.MigrationId).HasMaxLength(150);

                entity.Property(e => e.ContextKey).HasMaxLength(300);

                entity.Property(e => e.Model).IsRequired();

                entity.Property(e => e.ProductVersion)
                    .IsRequired()
                    .HasMaxLength(32);
            });

            modelBuilder.Entity<StudentAddresses>(entity =>
            {
                entity.HasKey(e => e.StudentAddressId);

                entity.HasIndex(e => e.StudentAddressId)
                    .HasName("IX_StudentAddressId");

                entity.Property(e => e.StudentAddressId).ValueGeneratedNever();

                entity.HasOne(d => d.StudentAddress)
                    .WithOne(p => p.StudentAddresses)
                    .HasForeignKey<StudentAddresses>(d => d.StudentAddressId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.StudentAddresses_dbo.Students_StudentAddressId");
            });

            modelBuilder.Entity<StudentCourses>(entity =>
            {
                entity.HasKey(e => new { e.StudentStudentId, e.CourseCourseId });

                entity.HasIndex(e => e.CourseCourseId)
                    .HasName("IX_Course_CourseId");

                entity.HasIndex(e => e.StudentStudentId)
                    .HasName("IX_Student_StudentID");

                entity.Property(e => e.StudentStudentId).HasColumnName("Student_StudentID");

                entity.Property(e => e.CourseCourseId).HasColumnName("Course_CourseId");

                entity.HasOne(d => d.CourseCourse)
                    .WithMany(p => p.StudentCourses)
                    .HasForeignKey(d => d.CourseCourseId)
                    .HasConstraintName("FK_dbo.StudentCourses_dbo.Courses_Course_CourseId");

                entity.HasOne(d => d.StudentStudent)
                    .WithMany(p => p.StudentCourses)
                    .HasForeignKey(d => d.StudentStudentId)
                    .HasConstraintName("FK_dbo.StudentCourses_dbo.Students_Student_StudentID");
            });

            modelBuilder.Entity<Students>(entity =>
            {
                entity.HasKey(e => e.StudentId);

                entity.HasIndex(e => e.GradeId)
                    .HasName("IX_GradeId");

                entity.Property(e => e.StudentId).HasColumnName("StudentID");

                entity.Property(e => e.DateOfBirth).HasColumnType("datetime");

                entity.Property(e => e.StudentName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.Grade)
                    .WithMany(p => p.Students)
                    .HasForeignKey(d => d.GradeId)
                    .HasConstraintName("FK_dbo.Students_dbo.Grades_GradeId");
            });
        }
    }
}
