using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using DabAflevering2.Entities;
using DabAflevering2.DBContext;


namespace DabAflevering2
{
    class CreateData
    {

        public void CreateNewStudent()
        {
            using var db = new DabDBContext();
            StudentEntity student = new StudentEntity();
            Console.WriteLine("Write student name:");
            student.Name = Console.ReadLine();
            db.Add(student);
        }
        public void CreateNewTeacher()
        {
            using var db = new DabDBContext();
            TeacherEntity teacher = new TeacherEntity();
            Console.WriteLine("write teacher name:");
            teacher.Name = Console.ReadLine();
            db.Add(teacher);
        }
        public void CreateNewExecersise()
        {
            using var db = new DabDBContext();
            ExerciseEntity exercise = new ExerciseEntity();
            Console.WriteLine("Write nr of the exercise:");
            exercise.Number = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("write name of lecture");
            exercise.Lecture = Console.ReadLine();
            db.Add(exercise);
        }
        public void CreateNewAssignment()
        {
            using var db = new DabDBContext();
            AssignmentEntity assignment = new AssignmentEntity();
            db.Add(assignment);
        }
        public void CreateNewCourseData()
        {
            using var db = new DabDBContext();
            CourseEntity course = new CourseEntity();
            Console.WriteLine("Write name of course:");
            course.Name = Console.ReadLine();
            db.Add(course);
        }
        public void CreateNewHelpRequestExercise()
        {
            using var db = new DabDBContext();
            var student = db.Set<StudentEntity>().ToList();
            int i = 0;
            foreach (var x in student)
            {
                Console.WriteLine(
                    "Nr:" + i +
                    "Student ID " + x.AuId +
                    "Student Name: " + x.Name);
                i++;
            }
            Console.WriteLine("Type Nr of the user to request help:");
            int id = Convert.ToInt32(Console.ReadLine());

            var exercise = db.Set<ExerciseEntity>().ToList();
            i = 0;
            foreach (var x in exercise)
            {
                Console.WriteLine(
                    "Nr:" + i +
                    "Exercise Name: " + x.Lecture);
                i++;
            }
            Console.WriteLine("Type Nr of the exercise you want help with:");
            int exeid = Convert.ToInt32(Console.ReadLine());

            exercise[exeid].Student.Name = student[id].Name;
            Console.WriteLine("Write where you want help:");
            exercise[exeid].HelpWhere = Console.ReadLine();
        }
        public void CreateNewHelpRequestAssignment()
        {
            using var db = new DabDBContext();
            var student = db.Set<StudentEntity>().ToList();
            int i = 0;
            foreach (var x in student)
            {
                Console.WriteLine(
                    "Nr:" + i + "\n" +
                    "Student ID " + x.AuId + "\n" +
                    "Student Name: " + x.Name);
                i++;
            }
            Console.WriteLine("Type Nr of the user to request help:");
            int id = Convert.ToInt32(Console.ReadLine());

            var shadow = db.Set<AssignmentStudentEntity>().ToList();
            var assignment = db.Set<AssignmentEntity>().ToList();
            i = 0;
            foreach (var x in assignment)
            {
                Console.WriteLine(
                    "Nr:" + i + "\n" +
                    "Exercise Id: " + x.AssignmentId);
                i++;
            }
            Console.WriteLine("Type Nr of the exercise you want help with:");
            int assId = Convert.ToInt32(Console.ReadLine());

            shadow[assId].Student.Name = student[id].Name;
            Console.WriteLine("Write where you want help:");
            exercise[exeid].HelpWhere = Console.ReadLine();
        }
    }
}
