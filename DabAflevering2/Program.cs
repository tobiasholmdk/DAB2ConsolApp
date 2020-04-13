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
            var db = new DabDBContext();
            var a = new DummyData(); 
            a.InsertDummyData();

            Console.WriteLine("Welcome to DabAflevering, for investigating the database use the following commands:");

            while (true)
            {
                Console.WriteLine("Press A, and enter for a list of all Teachers");
                Console.WriteLine("Press S, and enter for a list of all Students");
                Console.WriteLine("Press D, and enter for a list of all Assignments");
                Console.WriteLine("Press F, and enter for a list of all Exercises");
                Console.WriteLine("Press G, and enter for a list of all Courses");
                Console.WriteLine("Press Q, and get list over Assignments which need help");
                Console.WriteLine("Press W, and get list over help requests for course 2");
                
                var input = Console.ReadLine();
                
                switch (input)
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
                        //foreach (var x in assignments)
                            
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
                            Console.WriteLine("Course ID " + x.CourseId + " Course Name: " + x.Name + " Teacher " + x.Teachers );
                        }

                        break;
                    case "W":
                        var joins = db.Set<StudentCourseEntity>().ToList();
                        foreach (var x in joins)
                        {
                            Console.WriteLine("Course ID " + x.CourseId + " Course Name: " + x.StudentAuId + " Teacher " + x.Courses );
                        }
                        break;

                }
            } 
        }
        
        public static async Task<StudentEntity> GetById(int id)
        {
            var db = new DabDBContext();
            return await db.Set<StudentEntity>().FindAsync(id);
        }
    }
}