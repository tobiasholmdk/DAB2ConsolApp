﻿// <auto-generated />
using System;
using DabAflevering2.DBContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DabAflevering2.Migrations
{
    [DbContext(typeof(DabDBContext))]
    [Migration("20200413202646_iniial")]
    partial class iniial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.0-preview.2.20159.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DabAflevering2.Entities.AssignmentEntity", b =>
                {
                    b.Property<int>("AssignmentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CourseId")
                        .HasColumnType("int");

                    b.Property<int?>("TeacherAuId")
                        .HasColumnType("int");

                    b.HasKey("AssignmentId");

                    b.HasIndex("CourseId");

                    b.HasIndex("TeacherAuId");

                    b.ToTable("Assignments");
                });

            modelBuilder.Entity("DabAflevering2.Entities.AssignmentStudentEntity", b =>
                {
                    b.Property<int>("StudentAuId")
                        .HasColumnType("int");

                    b.Property<int>("AssignmentId")
                        .HasColumnType("int");

                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<bool>("NeedHelp")
                        .HasColumnType("bit");

                    b.HasKey("StudentAuId", "AssignmentId");

                    b.HasIndex("AssignmentId");

                    b.ToTable("AssignmentStudents");
                });

            modelBuilder.Entity("DabAflevering2.Entities.CourseEntity", b =>
                {
                    b.Property<int>("CourseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CourseId");

                    b.ToTable("Courses");
                });

            modelBuilder.Entity("DabAflevering2.Entities.ExerciseEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CourseId")
                        .HasColumnType("int");

                    b.Property<string>("HelpWhere")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Lecture")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Number")
                        .HasColumnType("int");

                    b.Property<int>("StudentId")
                        .HasColumnType("int");

                    b.Property<int>("TeacherIds")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CourseId");

                    b.HasIndex("StudentId");

                    b.HasIndex("TeacherIds");

                    b.ToTable("Exercises");
                });

            modelBuilder.Entity("DabAflevering2.Entities.StudentCourseEntity", b =>
                {
                    b.Property<int>("StudentAuId")
                        .HasColumnType("int");

                    b.Property<int>("CourseId")
                        .HasColumnType("int");

                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<int>("Semester")
                        .HasColumnType("int");

                    b.HasKey("StudentAuId", "CourseId");

                    b.HasIndex("CourseId");

                    b.ToTable("StudentsCourses");
                });

            modelBuilder.Entity("DabAflevering2.Entities.StudentEntity", b =>
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

            modelBuilder.Entity("DabAflevering2.Entities.TeacherEntity", b =>
                {
                    b.Property<int>("AuId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CourseId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AuId");

                    b.HasIndex("CourseId");

                    b.ToTable("Teachers");
                });

            modelBuilder.Entity("DabAflevering2.Entities.AssignmentEntity", b =>
                {
                    b.HasOne("DabAflevering2.Entities.CourseEntity", "Course")
                        .WithMany("Assignments")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DabAflevering2.Entities.TeacherEntity", "Teacher")
                        .WithMany("Assignments")
                        .HasForeignKey("TeacherAuId");
                });

            modelBuilder.Entity("DabAflevering2.Entities.AssignmentStudentEntity", b =>
                {
                    b.HasOne("DabAflevering2.Entities.AssignmentEntity", "Assignments")
                        .WithMany("Students")
                        .HasForeignKey("AssignmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DabAflevering2.Entities.StudentEntity", "Students")
                        .WithMany("Assignments")
                        .HasForeignKey("StudentAuId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DabAflevering2.Entities.ExerciseEntity", b =>
                {
                    b.HasOne("DabAflevering2.Entities.CourseEntity", "Course")
                        .WithMany("Exercises")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DabAflevering2.Entities.StudentEntity", "Student")
                        .WithMany("Exercises")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DabAflevering2.Entities.TeacherEntity", "Teacher")
                        .WithMany("Exercises")
                        .HasForeignKey("TeacherIds")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DabAflevering2.Entities.StudentCourseEntity", b =>
                {
                    b.HasOne("DabAflevering2.Entities.CourseEntity", "Courses")
                        .WithMany("Students")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DabAflevering2.Entities.StudentEntity", "Students")
                        .WithMany("Courses")
                        .HasForeignKey("StudentAuId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DabAflevering2.Entities.TeacherEntity", b =>
                {
                    b.HasOne("DabAflevering2.Entities.CourseEntity", "Course")
                        .WithMany("Teachers")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}