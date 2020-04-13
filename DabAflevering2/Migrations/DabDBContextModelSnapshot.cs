﻿// <auto-generated />
using System;
using DabAflevering2.DBContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DabAflevering2.Migrations
{
    [DbContext(typeof(DabDBContext))]
    partial class DabDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.0-preview.2.20159.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Dab_aflevering_2.Entities.AssignmentEntity", b =>
                {
                    b.Property<int>("AssignmentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CourseId")
                        .HasColumnType("int");

                    b.Property<int?>("TeacherAuId")
                        .HasColumnType("int");

                    b.HasKey("AssignmentId");

                    b.HasIndex("CourseId");

                    b.HasIndex("TeacherAuId");

                    b.ToTable("Assignments");
                });

            modelBuilder.Entity("Dab_aflevering_2.Entities.AssignmentStudentEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AssignmentId")
                        .HasColumnType("int");

                    b.Property<int?>("AssignmentsAssignmentId")
                        .HasColumnType("int");

                    b.Property<bool>("NeedHelp")
                        .HasColumnType("bit");

                    b.Property<int>("StudentAuId")
                        .HasColumnType("int");

                    b.Property<int?>("StudentsAuId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AssignmentsAssignmentId");

                    b.HasIndex("StudentsAuId");

                    b.ToTable("AssignmentStudents");
                });

            modelBuilder.Entity("Dab_aflevering_2.Entities.CourseEntity", b =>
                {
                    b.Property<int>("CourseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("StudentEntityAuId")
                        .HasColumnType("int");

                    b.HasKey("CourseId");

                    b.HasIndex("StudentEntityAuId");

                    b.ToTable("Courses");
                });

            modelBuilder.Entity("Dab_aflevering_2.Entities.ExerciseEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("HelpWhere")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Lecture")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Number")
                        .HasColumnType("int");

                    b.Property<int?>("StudentAuId")
                        .HasColumnType("int");

                    b.Property<int?>("TeacherAuId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("StudentAuId");

                    b.HasIndex("TeacherAuId");

                    b.ToTable("Exercises");
                });

            modelBuilder.Entity("Dab_aflevering_2.Entities.StudentCourseEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CourseId")
                        .HasColumnType("int");

                    b.Property<int?>("CoursesCourseId")
                        .HasColumnType("int");

                    b.Property<int>("Semester")
                        .HasColumnType("int");

                    b.Property<int>("StudentAuId")
                        .HasColumnType("int");

                    b.Property<int?>("StudentsAuId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CoursesCourseId");

                    b.HasIndex("StudentsAuId");

                    b.ToTable("StudentsCourses");
                });

            modelBuilder.Entity("Dab_aflevering_2.Entities.StudentEntity", b =>
                {
                    b.Property<int>("AuId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AuId");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("Dab_aflevering_2.Entities.TeacherEntity", b =>
                {
                    b.Property<int>("AuId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CourseId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AuId");

                    b.HasIndex("CourseId");

                    b.ToTable("Teachers");
                });

            modelBuilder.Entity("Dab_aflevering_2.Entities.AssignmentEntity", b =>
                {
                    b.HasOne("Dab_aflevering_2.Entities.CourseEntity", "Course")
                        .WithMany("Assignments")
                        .HasForeignKey("CourseId");

                    b.HasOne("Dab_aflevering_2.Entities.TeacherEntity", "Teacher")
                        .WithMany("Assignments")
                        .HasForeignKey("TeacherAuId");
                });

            modelBuilder.Entity("Dab_aflevering_2.Entities.AssignmentStudentEntity", b =>
                {
                    b.HasOne("Dab_aflevering_2.Entities.AssignmentEntity", "Assignments")
                        .WithMany("Students")
                        .HasForeignKey("AssignmentsAssignmentId");

                    b.HasOne("Dab_aflevering_2.Entities.StudentEntity", "Students")
                        .WithMany("Assignments")
                        .HasForeignKey("StudentsAuId");
                });

            modelBuilder.Entity("Dab_aflevering_2.Entities.CourseEntity", b =>
                {
                    b.HasOne("Dab_aflevering_2.Entities.StudentEntity", null)
                        .WithMany("Courses")
                        .HasForeignKey("StudentEntityAuId");
                });

            modelBuilder.Entity("Dab_aflevering_2.Entities.ExerciseEntity", b =>
                {
                    b.HasOne("Dab_aflevering_2.Entities.StudentEntity", "Student")
                        .WithMany("Exercises")
                        .HasForeignKey("StudentAuId");

                    b.HasOne("Dab_aflevering_2.Entities.TeacherEntity", "Teacher")
                        .WithMany("Exercises")
                        .HasForeignKey("TeacherAuId");
                });

            modelBuilder.Entity("Dab_aflevering_2.Entities.StudentCourseEntity", b =>
                {
                    b.HasOne("Dab_aflevering_2.Entities.CourseEntity", "Courses")
                        .WithMany("Students")
                        .HasForeignKey("CoursesCourseId");

                    b.HasOne("Dab_aflevering_2.Entities.StudentEntity", "Students")
                        .WithMany()
                        .HasForeignKey("StudentsAuId");
                });

            modelBuilder.Entity("Dab_aflevering_2.Entities.TeacherEntity", b =>
                {
                    b.HasOne("Dab_aflevering_2.Entities.CourseEntity", "Course")
                        .WithMany("Teachers")
                        .HasForeignKey("CourseId");
                });
#pragma warning restore 612, 618
        }
    }
}
