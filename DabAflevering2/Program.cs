using System;
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
                                    var courses1 = db.Set<CourseEntity>().ToList();
                                    foreach (var x in courses1)
                                    {
                                        Console.WriteLine("Course ID " + x.CourseId + " Course Name: " + x.Name + " Teacher " + x.Teachers);
                                    }

                                    break;

                                case "Q": //given a teacher select course and find all students that need help with that course

                                    var courses = db.Courses
                                        .Include(t => t.Teachers)
                                        .Include(a => a.Assignments)
                                            .ThenInclude(s => s.Students)
                                        .Include(e => e.Exercises).ToList();

                                    Console.WriteLine("Choose a Course ID");
                                    foreach (var co in courses)
                                    {
                                        Console.WriteLine("Course Name: " + co.Name + "  Course ID " + co.CourseId);
                                    }
                                    var inputCourse = Convert.ToInt32(Console.ReadLine());

                                    Console.WriteLine("Choose a Teacher");
                                    var course = courses.Find(i => i.CourseId == inputCourse);
                                    foreach (var t in course.Teachers)
                                    {
                                        Console.WriteLine("Teacher Name:" + t.Name + " Teacher Id " + t.AuId);
                                    }
                                    var inputTeacher = Console.ReadLine();
                                    foreach (var ass in course.Assignments)
                                    {
                                        foreach (var s in ass.Students)
                                        {
                                            if (s.NeedHelp == true)
                                            {
                                                Console.WriteLine("Student " + s.StudentAuId + " Needs help with assignment " + ass.AssignmentId + " in course " + course.Name);
                                            }
                                        }
                                    }
                                    foreach(var ex in course.Exercises)
                                    {
                                        if(ex.HelpWhere != null)
                                        {
                                            Console.WriteLine("Student " + ex.StudentId + " Needs help with exercise " + ex.Id + " in course " + course.Name);
                                        }
                                    }
                                    break;

                                case "W":
                                    var students1 = db.Students
                                        .Include(a => a.Assignments)
                                        .Include(e => e.Exercises)
                                        .ToList();
                                    int i = 0;
                                    foreach (var x in students1)
                                    {
                                        Console.WriteLine(
                                            " Nr:" + i + "\n" +
                                            " Student AUId " + x.AuId + "\n" +
                                            " Student Name: " + x.Name);
                                        i++;
                                    }
                                    Console.WriteLine("Write student auId to find his/hers help requests: ");
                                    int auId = Convert.ToInt32(Console.ReadLine());
                                    var student = students1.Find(x => x.AuId == auId);

                                    foreach (var x in student.Assignments)
                                    {
                                        if (x.NeedHelp != false)
                                        {
                                            Console.WriteLine("Needs help at: " + x.NeedHelp);
                                            Console.WriteLine("Contact info: au" + x.StudentAuId + "@post.au.dk");
                                        }
                                    }
                                    foreach (var x in student.Exercises)
                                    {
                                        if (x.HelpWhere != null)
                                        {
                                            Console.WriteLine("Needs help at: " + x.HelpWhere);
                                            Console.WriteLine("Contact info: au" + x.StudentId + "@post.au.dk");
                                        }
                                    }
                                    break;
                                case "s":
                                    var allCourses = db.Courses
                                        .Include(e => e.Exercises)
                                        .Include(a => a.Assignments)
                                            .ThenInclude(s => s.Students).ToList();
                                    foreach(var y in allCourses)
                                    {
                                        Console.WriteLine("Course " + y.Name + " has " + y.Assignments.Count() + " Assignments & " + y.Exercises.Count() + " exercises");
                                        int index = 0;
                                        foreach(var ass in y.Assignments)
                                        {
                                            foreach(var s in ass.Students)
                                            {
                                                if(s.NeedHelp == true)
                                                {
                                                    index++;
                                                }
                                            }
                                        }
                                        Console.WriteLine("there are " + index + " open request for assignemts and " + y.Exercises.Where(x => x.HelpWhere != null).Count() + " exercises open");
                                    }
                                    break;
                            }
                            break;
                    }
                } 
            }
        }
    }
}