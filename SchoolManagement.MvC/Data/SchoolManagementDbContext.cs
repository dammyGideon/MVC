using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace SchoolManagement.MvC.Data;

public partial class SchoolManagementDbContext : DbContext
{
    public SchoolManagementDbContext()
    {
    }

    public SchoolManagementDbContext(DbContextOptions<SchoolManagementDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Class> Classes { get; set; }

    public virtual DbSet<Course> Courses { get; set; }

    public virtual DbSet<Entrollment> Entrollments { get; set; }

    public virtual DbSet<Lecturer> Lecturers { get; set; }

    public virtual DbSet<NoTeachingStaff> NoTeachingStaffs { get; set; }

    public virtual DbSet<Student> Students { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Class>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Classes__3214EC07776077A4");

            entity.HasOne(d => d.Course).WithMany(p => p.Classes)
                .HasForeignKey(d => d.CourseId)
                .HasConstraintName("FK__Classes__CourseI__4CA06362");

            entity.HasOne(d => d.Lecturer).WithMany(p => p.Classes)
                .HasForeignKey(d => d.LecturerId)
                .HasConstraintName("FK__Classes__Lecture__4BAC3F29");
        });

        modelBuilder.Entity<Course>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Courses__3214EC07F726CC63");

            entity.HasIndex(e => e.Course1, "UQ__Courses__1544280E98840827").IsUnique();

            entity.Property(e => e.Course1)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("Course");
            entity.Property(e => e.Credit).HasColumnName("credit");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Entrollment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Entrollm__3214EC07F1B34065");

            entity.Property(e => e.Grade)
                .HasMaxLength(2)
                .IsUnicode(false);

            entity.HasOne(d => d.Class).WithMany(p => p.Entrollments)
                .HasForeignKey(d => d.ClassId)
                .HasConstraintName("FK__Entrollme__Class__5070F446");

            entity.HasOne(d => d.Student).WithMany(p => p.Entrollments)
                .HasForeignKey(d => d.StudentId)
                .HasConstraintName("FK__Entrollme__Stude__4F7CD00D");
        });

        modelBuilder.Entity<Lecturer>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Lecturer__3214EC0734DC9C37");

            entity.Property(e => e.FirstName)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.LastName)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<NoTeachingStaff>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__NoTeachi__3214EC07CFEFE575");

            entity.ToTable("NoTeachingStaff");

            entity.Property(e => e.FirstName)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.LastName)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Student>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Student__3214EC07DFA1A106");

            entity.ToTable("Student");

            entity.Property(e => e.FirstName)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.LastName)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
