using System;
using System.Linq;
using DabAflevering2.DBContext;
using DabAflevering2.Entities;

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
                        Console.WriteLine("----------------------------------------------------------------------------------------");
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
            
            var teachersList = _db.Set<TeacherEntity>().ToList();
            var courseIDs = _db.Set<CourseEntity>().ToList();

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

            var joined = _db.Teachers
                .Join(_db.Exercises,
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
                                    
            var finaljoin = joined.Join(_db.AssignmentStudents, j => j.CourseID, a => a.AssignmentId,
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
        }

        private void HelpByStudentView()
        {
            var student = _db.Set<StudentEntity>().ToList();
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
            var helprequests = _db.Set<ExerciseEntity>().ToList();
            var test = helprequests.Where(x =>
                (x.HelpWhere != null) && (x.StudentId == auId));
            test.ToList();

            foreach (var x in test)
            {
                Console.WriteLine("Needs help at: " + x.HelpWhere); 
                Console.WriteLine("Contact info: au" + x.StudentId + "@post.au.dk");
            }
        }

        private void HelpstatsView()
        {
            int ExerciseCount = _db.Exercises.Count(t => t.HelpWhere == null);
            int AssignmentCount = _db.AssignmentStudents.Count(t => t.NeedHelp == false);
            int ExerciseTotal = _db.Exercises.Count(t => t.HelpWhere != null);
            int AssignmentTotal = _db.AssignmentStudents.Count(t => t.NeedHelp == true);

            Console.WriteLine("Number of open requests: " + (ExerciseTotal + AssignmentTotal));
            Console.WriteLine("Number of close requests: " + (ExerciseCount + AssignmentCount));
        }
    }
}