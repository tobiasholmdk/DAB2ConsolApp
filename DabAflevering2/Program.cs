using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using DabAflevering2.DBContext;
using DabAflevering2.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace DabAflevering2
{
    class Program
    {
        static void Main(string[] args)
        {
            var c = new CreateData();
            var db = new DabDBContext();
            var a = new DummyData(); 
            a.InsertDummyData();

            Console.WriteLine("Welcome to DabAflevering, for investigating the database use the following commands:");

            while (true)
            {
                Console.WriteLine("Press A to list data");
                Console.WriteLine("Press C, to create new data");

                var input = Console.ReadLine();
                
                switch (input)
                {
                    case "V":
                        c.View(db);
                        break;
                    case "C":
                        c.CreateDataHandler(db);
                        db.SaveChanges();
                        break;
                    case "A":
                    {
                    Console.WriteLine("Press A, and enter for a list of all Teachers");
                    Console.WriteLine("Press S, and enter for a list of all Students");
                    Console.WriteLine("Press D, and enter for a list of all Assignments");
                    Console.WriteLine("Press F, and enter for a list of all Exercises");
                    Console.WriteLine("Press G, and enter for a list of all Courses");
                    Console.WriteLine("Press Q, and get list over Assignments which need help for a teacher and his course");
                    Console.WriteLine("Press W, and get list over help requests for course 2");
                
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
                                 Console.WriteLine("Assigment ID " + x.AssignmentId );
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
                              Console.WriteLine("Course ID " + x.CourseId + " Course Name: " + x.Name + " Teacher " + x.Teachers );
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
                                ).Where(e => (e.HelpWhere!=null) && (e.TeacherName == inputTeacher) && (e.CourseID == inputCourse)).ToList();
                            foreach (var x in joined)
                            {
                                Console.WriteLine("Student " + "Needs help at: " + x.HelpWhere + " Student info: " + x.StudentID+ "@post.au.dk" );
                            }

                            break;
                        
                          
                        case "W":
                            var helprequests = db.Set<ExerciseEntity>().ToList();
                            var test = helprequests.Where(x =>
                                (x.HelpWhere != null));
                            test.ToList();
                            
                            foreach (var x in test)
                            {
                                Console.WriteLine("Student"  + x.Course.Name +  "Needs help at: " + x.HelpWhere + " Student info " );
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