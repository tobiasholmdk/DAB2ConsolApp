using System;
using System.Collections.Generic;
using System.Text;
using DabAflevering2.Entities;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace DabAflevering2
{
    class test
    {
        public void lol()
        {
            var db = new DBContext.DabDBContext();
            string cadsa = "Q";
            switch (cadsa)
            {
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
                    foreach (var ex in course.Exercises)
                    {
                        if (ex.HelpWhere != null)
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
                    foreach (var y in allCourses)
                    {
                        Console.WriteLine("Course " + y.Name + " has " + y.Assignments.Count() + " Assignments & " + y.Exercises.Count() + " exercises");
                        int index = 0;
                        foreach (var ass in y.Assignments)
                        {
                            foreach (var s in ass.Students)
                            {
                                if (s.NeedHelp == true)
                                {
                                    index++;
                                }
                            }
                        }
                        Console.WriteLine("there are " + index + " open request for assignemts and " + y.Exercises.Where(x => x.HelpWhere != null).Count() + " exercises open");
                    }
                    break;
            }
        }
    }
}
