using System;
using System.Linq;
using DabAflevering2.DBContext;
using DabAflevering2.Entities;
using Microsoft.EntityFrameworkCore;

namespace DabAflevering2
{
    public class Views
    {
        private DabDBContext _db; 
        public Views(DabDBContext db)
        {
            _db = db;
            StudentEntity student = new StudentEntity();
        }
        
        public void ViewsSwitcher()
        { 
            bool leave = false;
            while(!leave)
            {
                Console.Clear();
                Console.WriteLine("Press 1, and enter for a list of all Teachers");
                Console.WriteLine("Press 2, and enter for a list of all Students");
                Console.WriteLine("Press 3, and enter for a list of all Assignments");
                Console.WriteLine("Press 4, and enter for a list of all Exercises");
                Console.WriteLine("Press 5, and enter for a list of all Courses");
                Console.WriteLine("Press 6, and get list over Assignments which need help for a teacher and the course");
                Console.WriteLine("Press 7, and get list over help requests from a student");
                Console.WriteLine("Press 8, and get statistics of request");
                Console.WriteLine("Any other key to go back");
                Console.WriteLine("----------------------------------------------------------------------------------------");

                var input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        TeachersView();
                        Console.WriteLine("----------------------------------------------------------------------------------------");
                        Console.WriteLine("Press a key to continue");
                        Console.ReadLine();
                        break;
                    case "2":
                        StudentsView();
                        Console.WriteLine("----------------------------------------------------------------------------------------");
                        Console.WriteLine("Press a key to continue");
                        Console.ReadLine();
                        break;
                    case "3":
                        AssignmentsView();
                        Console.WriteLine("----------------------------------------------------------------------------------------");
                        Console.WriteLine("Press a key to continue");
                        Console.ReadLine();
                        break;
                    case "4":
                        ExercisesView();
                        Console.WriteLine("----------------------------------------------------------------------------------------");
                        Console.WriteLine("Press a key to continue");
                        Console.ReadLine();
                        break;
                    case "5":
                        CoursesView();
                        Console.WriteLine("----------------------------------------------------------------------------------------");
                        Console.WriteLine("Press a key to continue");
                        Console.ReadLine();
                        break;
                    case "6":
                        helpByTeacherAndCourseView();
                        Console.WriteLine("----------------------------------------------------------------------------------------");
                        Console.WriteLine("Press a key to continue");
                        Console.ReadLine();
                        break;
                    case "7":
                        HelpByStudentView();
                        Console.WriteLine("Press a key to continue");
                        Console.ReadLine();
                        break;
                    case "8":
                        HelpstatsView();
                        Console.WriteLine("----------------------------------------------------------------------------------------");
                        Console.WriteLine("Press a key to continue");
                        Console.ReadLine();
                        break;
                    default:
                        leave = true;
                        break;
                }
            }
        }

        private void TeachersView()
        {
            var teachers = _db.Set<TeacherEntity>().ToList();
            foreach (TeacherEntity x in teachers) 
                Console.WriteLine("AU ID: " + x.AuId + " Teacher Name: " + x.Name + x.Exercises);
        }

        private void StudentsView()
        {
            var students = _db.Set<StudentEntity>().ToList();
            foreach (var x in students)
                Console.WriteLine("AU ID: " + x.AuId + " Student Name: " + x.Name + x.Exercises + x.Courses);
        }
        private void AssignmentsView()
        {
            var assignments = _db.Set<AssignmentEntity>().ToList();
            foreach (var x in assignments)
                Console.WriteLine("Assigment ID " + x.AssignmentId);
        }

        private void ExercisesView()
        {
            var exercises = _db.Set<ExerciseEntity>().ToList();
            foreach (var x in exercises)
                Console.WriteLine("Exercise Number " + x.Number + " Help with? " + x.HelpWhere + " Lecture: " + x.Lecture);
        }

        private void CoursesView()
        {
            var courses = _db.Set<CourseEntity>().ToList();
            foreach (var x in courses)
            {
                Console.WriteLine("Course ID " + x.CourseId + " Course Name: " + x.Name + " Teacher " + x.Teachers);
            }
        }

        private void helpByTeacherAndCourseView()
        {
            var courses = _db.Courses
                .Include(t => t.Teachers)
                .Include(a => a.Assignments)
                .ThenInclude(s => s.Students)
                .Include(e => e.Exercises).ToList();
            Console.WriteLine("----------------------------------------------------------------------------------------");
            Console.WriteLine("Choose a Course ID");
            foreach (var co in courses)
            {
                Console.WriteLine("Course Name: " + co.Name + "  Course ID " + co.CourseId);
                Console.WriteLine("----------------------------------------------------------------------------------------");
            }
            var inputCourse = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("----------------------------------------------------------------------------------------");
            Console.WriteLine("Choose a Teacher");
            var course = courses.Find(i => i.CourseId == inputCourse);
            foreach (var t in course.Teachers)
            {
                Console.WriteLine("Teacher Name:" + t.Name + " Teacher Id " + t.AuId);
                Console.WriteLine("----------------------------------------------------------------------------------------");
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
                    Console.WriteLine("----------------------------------------------------------------------------------------");
                }
            }
            foreach (var ex in course.Exercises)
            {
                if (ex.HelpWhere != null)
                {
                    Console.WriteLine("Student " + ex.StudentId + " Needs help with exercise " + ex.Id + " in course " + course.Name);
                }
                Console.WriteLine("----------------------------------------------------------------------------------------");
            }
        }

        private void HelpByStudentView()
        {
            var students1 = _db.Students
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
                Console.WriteLine("----------------------------------------------------------------------------------------");
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
                Console.WriteLine("----------------------------------------------------------------------------------------");
            }
            foreach (var x in student.Exercises)
            {
                if (x.HelpWhere != null)
                {
                    Console.WriteLine("Needs help at: " + x.HelpWhere);
                    Console.WriteLine("Contact info: au" + x.StudentId + "@post.au.dk");
                }
                Console.WriteLine("----------------------------------------------------------------------------------------");
            }
        }

        private void HelpstatsView()
        {
            var allCourses = _db.Courses
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
                Console.WriteLine("----------------------------------------------------------------------------------------");
                Console.WriteLine("there are " + index + " open request for assignemts and " + y.Exercises.Where(x => x.HelpWhere != null).Count() + " exercises open");
            }
        }
    }
}