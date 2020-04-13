using DabAflevering2.DBContext;
using DabAflevering2.Entities;
using System.Collections.Generic;

namespace DabAflevering2
{
    public class DummyData
    {
        public void InsertDummyData()
        {
            using var db = new DabDBContext();
            
            TeacherEntity teacher1 = new TeacherEntity();
            teacher1.Name = "Henrik Kirk";
            db.Add(teacher1);
 
            TeacherEntity teacher2 = new TeacherEntity();
            teacher2.Name = "Søren";
            db.Add(teacher1);
                    
            StudentEntity student1 = new StudentEntity();
            student1.Name = "Sebastian";
            db.Add(student1);
                    
            StudentEntity student2 = new StudentEntity();
            student2.Name = "Tobias";
            db.Add(student2);

            StudentEntity student0 = new StudentEntity();
            student0.Name = "Gustav";
            db.Add(student0);

            ExerciseEntity exercise1 = new ExerciseEntity();
            exercise1.Number = 2;
            exercise1.Lecture = "3 EF core";
            exercise1.Teacher = teacher1;
            db.Add(exercise1);

            ExerciseEntity exercise2 = new ExerciseEntity();
            exercise2.Number = 3;
            exercise2.Lecture = "3 EF core";
            exercise2.Teacher = teacher1;
            db.Add(exercise2);

           
            AssignmentEntity assignment1 = new AssignmentEntity();
            assignment1.Teacher = teacher2;
            db.Add(assignment1);
            AssignmentEntity assignment2 = new AssignmentEntity();
            assignment2.Teacher = teacher2;
            db.Add(assignment2);

            CourseEntity course = new CourseEntity()
            {
                Name = "Databaser",
                Assignments = new List<AssignmentEntity>
                {
                    new AssignmentEntity
                    {
                        Teacher = teacher1
                    },
                    assignment1,
                    assignment2
                },
                Teachers = new List<TeacherEntity>()
                { 
                    teacher1,
                    teacher2
                }
            };
            db.Add(course);

            db.SaveChanges();
        }

    }
}