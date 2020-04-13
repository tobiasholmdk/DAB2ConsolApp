using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using DabAflevering2.Entities;
using DabAflevering2.DBContext;


namespace DabAflevering2
{
    public class CreateData
    {

        public void CreateNewStudent(DabDBContext db)
        {
            StudentEntity student = new StudentEntity();
            Console.WriteLine("Write student name:");
            student.Name = Console.ReadLine();
            db.Add(student);
        }
        public void CreateNewTeacher(DabDBContext db)
        {
            TeacherEntity teacher = new TeacherEntity();
            Console.WriteLine("write teacher name:");
            teacher.Name = Console.ReadLine();
            db.Add(teacher);
        }
        public void CreateNewExecersise(DabDBContext db)
        {
            ExerciseEntity exercise = new ExerciseEntity();
            Console.WriteLine("Write nr of the exercise:");
            exercise.Number = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("write name of lecture");
            exercise.Lecture = Console.ReadLine();
            db.Add(exercise);
        }
        public void CreateNewAssignment(DabDBContext db)
        {
            AssignmentEntity assignment = new AssignmentEntity();
            db.Add(assignment);
        }
        public void CreateNewCourse(DabDBContext db)
        {
            CourseEntity course = new CourseEntity();
            Console.WriteLine("Write name of course:");
            course.Name = Console.ReadLine();
            db.Add(course);
        }
        public void CreateNewHelpRequestExercise(DabDBContext db)
        {
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
        public void CreateNewHelpRequestAssignment(DabDBContext db)
        {
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

            shadow[assId].NeedHelp = true;
        }
        public void CreateDataHandler(DabDBContext db)
        {
            bool leave = false;
            while(!leave)
            {
                Console.WriteLine("Press a key to create different objects");
                Console.WriteLine("A for student, B for teacher");
                Console.WriteLine("C for Exercse, D for Assignment, E for Course");
                Console.WriteLine("F for help with exercise, G for help with assigment");
                Console.WriteLine("Any other key to go back");
                var input = Console.ReadLine();
                switch (input)
                {
                    case "A":
                        CreateNewStudent(db);
                        break;
                    case "B":
                        CreateNewTeacher(db);
                        break;
                    case "C":
                        CreateNewExecersise(db);
                        break;
                    case "D":
                        CreateNewAssignment(db);
                        break;
                    case "E":
                        CreateNewCourse(db);
                        break;
                    case "F":
                        CreateNewHelpRequestExercise(db);
                        break;
                    case "G":
                        CreateNewHelpRequestAssignment(db);
                        break;
                    default:
                        leave = true;
                        break;
                }
            }
        }
    }
}
