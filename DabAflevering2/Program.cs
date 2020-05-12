﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using DabAflevering2.DBContext;
using DabAflevering2.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

/* Dab aflevering 2: Medlemmer, Tobias Holm, Gustav Hjortshøj Sørensen og Sebastian Laczek Nielsen */


namespace DabAflevering2
{
    class Program
    {
        static void Main(string[] args)
        {
            var c = new CreateData();
            var db = new DabDBContext();
            var a = new DummyData();

            Console.WriteLine("Welcome to DabAflevering, for investigating the database use the following commands:");

            while (true)
            {
                Console.WriteLine("Press A to list data");
                Console.WriteLine("Press D To add Dummy Data");
                Console.WriteLine("Press C, to create new data");

                var input = Console.ReadLine();
                
                switch (input)
                {
                    case "C":
                        c.CreateDataHandler(db);
                        db.SaveChanges();
                        break;
                    case "D":
                        a.InsertDummyData();
                        break;
                    case "A":
                        {
                            Console.WriteLine("Press A, and enter for a list of all Teachers");
                            Console.WriteLine("Press S, and enter for a list of all Students");
                            Console.WriteLine("Press D, and enter for a list of all Assignments");
                            Console.WriteLine("Press F, and enter for a list of all Exercises");
                            Console.WriteLine("Press G, and enter for a list of all Courses");
                            Console.WriteLine("Press Q, and get list over Assignments which need help for a teacher and the course");
                            Console.WriteLine("Press W, and get list over help requests from a student");
                            Console.WriteLine("Press s, and get statistics of request");

                            var input2 = Console.ReadLine();
                            switch (input2)
                            {
                                case "A":
                                    var teachers = db.Set<TeacherEntity>().ToList();
                                    foreach (TeacherEntity x in teachers)
                                        Console.WriteLine("AU ID: " + x.AuId + " Teacher Name: " + x.Name + x.Exercises);
                                    break;
                                case "S":
                                    var students = db.Set<StudentEntity>().ToList();
                                    foreach (var x in students)
                                        Console.WriteLine("AU ID: " + x.AuId + " Student Name: " + x.Name + x.Exercises + x.Courses);
                                    break;
                                case "D":
                                    var assignments = db.Set<AssignmentEntity>().ToList();
                                    foreach (var x in assignments)
                                        Console.WriteLine("Assigment ID " + x.AssignmentId);
                                    break;
                                case "F":
                                    var exercises = db.Set<ExerciseEntity>().ToList();
                                    foreach (var x in exercises)
                                        Console.WriteLine("Exercise Number " + x.Number + " Help with? " + x.HelpWhere + " Lecture: " + x.Lecture);
                                    break;
                                case "G":
                                    var courses = db.Set<CourseEntity>().ToList();
                                    foreach (var x in courses)
                                    {
                                        Console.WriteLine("Course ID " + x.CourseId + " Course Name: " + x.Name + " Teacher " + x.Teachers);
                                    }

                                    break;

                                case "Q":

                                    var teachersList = db.Set<TeacherEntity>().ToList();
                                    var courseIDs = db.Set<CourseEntity>().ToList();

                                    Console.WriteLine("Choose a Teacher");
                                    foreach (var x in teachersList)
                                    {
                                        Console.WriteLine("Teacher Name:" + x.Name);
                                    }
                                    var inputTeacher = Console.ReadLine();

                                    Console.WriteLine("Choose a Course ID");
                                    foreach (var x in courseIDs)
                                    {
                                        Console.WriteLine("Course Name: " + x.Name + "  Course ID " + x.CourseId);
                                    }
                                    var inputCourse = Convert.ToInt32(Console.ReadLine());

                                    var joined = db.Teachers
                                        .Join(db.Exercises,
                                            t => t.CourseId,
                                            e => e.CourseId,
                                            (t, e) => new
                                            {
                                                HelpWhere = e.HelpWhere,
                                                TeacherName = t.Name,
                                                CourseID = t.CourseId,
                                                StudentID = e.StudentId
                                            }
                                        ).Where(e => (e.HelpWhere != null) && (e.TeacherName == inputTeacher) && (e.CourseID == inputCourse)).ToList();
                                    
                                    var finaljoin = joined.Join(db.AssignmentStudents, j => j.CourseID, a => a.AssignmentId,
                                        (j, a) => new
                                        {
                                            HelpWhere = j.HelpWhere,
                                            TeacherName = j.TeacherName,
                                            CourseID = j.CourseID,
                                            StudentID = j.StudentID,
                                            AssignmentId = a.AssignmentId,
                                            AssignmentHelp = a.NeedHelp
                                        }).Where(x => x.AssignmentHelp != null).ToList();
                                    
                                    foreach (var x in finaljoin)
                                    {
                                        Console.WriteLine("Student " + x.StudentID + "Needs help at: " + x.HelpWhere + " Student info: au" + x.StudentID + "@post.au.dk");
                                    }
                                    break;

                                case "W":
                                    var student = db.Set<StudentEntity>().ToList();
                                    int i = 0;
                                    foreach (var x in student)
                                    {
                                        Console.WriteLine(
                                            " Nr:" + i + "\n" +
                                            " Student AUId " + x.AuId + "\n" +
                                            " Student Name: " + x.Name);
                                        i++;
                                    }
                                    Console.WriteLine("Write student auId to find his/hers help requests: ");
                                    int auId = Convert.ToInt32(Console.ReadLine());
                                    var helprequests = db.Set<ExerciseEntity>().ToList();
                                    var test = helprequests.Where(x =>
                                        (x.HelpWhere != null) && (x.StudentId == auId));
                                    test.ToList();

                                    foreach (var x in test)
                                    {
                                        Console.WriteLine("Needs help at: " + x.HelpWhere); 
                                        Console.WriteLine("Contact info: au" + x.StudentId + "@post.au.dk");
                                    }
                                    break;
                                case "s":
                                    int ExerciseCount = db.Exercises.Count(t => t.HelpWhere == null);
                                    int AssignmentCount = db.AssignmentStudents.Count(t => t.NeedHelp == false);
                                    int ExerciseTotal = db.Exercises.Count(t => t.HelpWhere != null);
                                    int AssignmentTotal = db.AssignmentStudents.Count(t => t.NeedHelp == true);

                                    Console.WriteLine("Number of open requests: " + (ExerciseTotal + AssignmentTotal));
                                    Console.WriteLine("Number of close requests: " + (ExerciseCount + AssignmentCount));
                                    break;

                            }
                            break;
                    }
                } 
            }
        }
    }
}