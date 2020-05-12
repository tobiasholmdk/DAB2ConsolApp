using System;
using System.Linq;
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
            Console.WriteLine("Write teacher name:");
            teacher.Name = Console.ReadLine();
            db.Add(teacher);
        }
        public void CreateNewExecersise(DabDBContext db)
        {
            ExerciseEntity exercise = new ExerciseEntity();
            Console.WriteLine("Write Nr of the exercise:");
            exercise.Number = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Write name of lecture");
            exercise.Lecture = Console.ReadLine();
            db.Add(exercise);
        }
        public void CreateNewAssignment(DabDBContext db)
        {
            AssignmentEntity assignment = new AssignmentEntity();
            Console.WriteLine("Write Nr of the Asssignment:");
            assignment.AssignmentId = Convert.ToInt32(Console.ReadLine());
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
                    " Nr: " + i +
                    " Student ID " + x.AuId +
                    " Student Name: " + x.Name);
                i++;
            }
            Console.WriteLine("Type Nr of the user to request help:");
            int id = Convert.ToInt32(Console.ReadLine());

            var exercise = db.Set<ExerciseEntity>().ToList();
            i = 0;
            foreach (var x in exercise)
            {
                Console.WriteLine(
                    " Nr:" + i +
                    " Exercise Name: " + x.Lecture);
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
                    " Nr:" + i + "\n" +
                    " Student ID " + x.AuId + "\n" +
                    " Student Name: " + x.Name);
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
                    " Nr:" + i + "\n" +
                    " Exercise Id: " + x.AssignmentId);
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
                Console.WriteLine("1 for student, 2 for teacher");
                Console.WriteLine("3 for Exercise, 4 for Assignment, 5 for Course");
                Console.WriteLine("6 for help with exercise, 7 for help with assignment");
                Console.WriteLine("Any other key to go back");
                Console.WriteLine("----------------------------------------------------------------------------------------");
                var input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        CreateNewStudent(db);
                        Console.Clear();
                        Console.WriteLine("Created!");
                        Console.WriteLine("----------------------------------------------------------------------------------------");
                        break;
                    case "2":
                        CreateNewTeacher(db);
                        Console.Clear();
                        Console.WriteLine("Created!");
                        Console.WriteLine("----------------------------------------------------------------------------------------");
                        break;
                    case "3":
                        CreateNewExecersise(db);
                        Console.Clear();
                        Console.WriteLine("Created!");
                        Console.WriteLine("----------------------------------------------------------------------------------------");
                        break;
                    case "4":
                        CreateNewAssignment(db);
                        Console.Clear();
                        Console.WriteLine("Created!");
                        Console.WriteLine("----------------------------------------------------------------------------------------");
                        break;
                    case "5":
                        CreateNewCourse(db);
                        Console.Clear();
                        Console.WriteLine("Created!");
                        Console.WriteLine("----------------------------------------------------------------------------------------");
                        break;
                    case "6":
                        CreateNewHelpRequestExercise(db);
                        Console.Clear();
                        Console.WriteLine("Created!");
                        Console.WriteLine("----------------------------------------------------------------------------------------");
                        break;
                    case "7":
                        CreateNewHelpRequestAssignment(db);
                        Console.Clear();
                        Console.WriteLine("Created!");
                        Console.WriteLine("----------------------------------------------------------------------------------------");
                        break;
                    default:
                        leave = true;
                        break;
                }
            }
        }
    }
}
