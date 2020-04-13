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
            teacher2.Name = "S�ren";
            db.Add(teacher2);
            
            TeacherEntity teacher3 = new TeacherEntity();
            teacher3.Name = "Michael";
            db.Add(teacher3);
            
            TeacherEntity teacher4 = new TeacherEntity();
            teacher4.Name = "Lars";
            db.Add(teacher4);
                    
            StudentEntity student1 = new StudentEntity();
            student1.Name = "Sebastian";  
            db.Add(student1);
                    
            StudentEntity student2 = new StudentEntity();
            student2.Name = "Tobias";
            db.Add(student2);

            StudentEntity student0 = new StudentEntity();
            student0.Name = "Gustav";
            db.Add(student0);

            AssignmentEntity assignment1 = new AssignmentEntity();
            assignment1.Teacher = teacher2;
            db.Add(assignment1);
            AssignmentEntity assignment2 = new AssignmentEntity();
            assignment2.Teacher = teacher2;
            db.Add(assignment2);
            AssignmentEntity assignment3 = new AssignmentEntity();
            assignment3.Teacher = teacher3;
            db.Add(assignment3);


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
            CourseEntity course3 = new CourseEntity()
            {
                Name = "MMLS",
                Assignments = new List<AssignmentEntity>
                {
                    new AssignmentEntity
                    {
                        Teacher = teacher3
                    }
                },
                Teachers = new List<TeacherEntity>()
                { 
                   teacher4
                }
            };
            
            db.Add(course3);
            CourseEntity course2 = new CourseEntity()
            {
                Name = "SWD",
                Assignments = new List<AssignmentEntity>
                {
                    new AssignmentEntity
                    {
                        Teacher = teacher1
                    },
                    assignment3
                },
                Teachers = new List<TeacherEntity>()
                {
                    teacher3
                }
            };
            
            db.Add(course2);
            
            ExerciseEntity exercise1 = new ExerciseEntity();
            exercise1.Number = 2;
            exercise1.Lecture = "3 EF core";
            exercise1.Teacher = teacher1;
            exercise1.Student = student1;
            exercise1.HelpWhere = "Ex 3.1";
            exercise1.Course = course;
            db.Add(exercise1);

            ExerciseEntity exercise2 = new ExerciseEntity();
            exercise2.Number = 5;
            exercise2.Lecture = "5 EF core";
            exercise2.Teacher = teacher1;
            exercise2.Student = student1;
            exercise2.HelpWhere = "Side 2";
            exercise2.Course = course;
            db.Add(exercise2);
            
            
            ExerciseEntity exercise3 = new ExerciseEntity();
            exercise3.Number = 1;
            exercise3.Lecture = "Design patterns";
            exercise3.Teacher = teacher3;
            exercise3.Student = student0;
            exercise3.HelpWhere = "Det hele";
            exercise3.Course = course2;
            db.Add(exercise3);
            
            ExerciseEntity exercise4 = new ExerciseEntity();
            exercise4.Number = 4;
            exercise4.Lecture = "Functional Programming";
            exercise4.Teacher = teacher1;
            exercise4.Student = student0;
            exercise4.Course = course2;
            db.Add(exercise4);

            ExerciseEntity exercise5 = new ExerciseEntity();
            exercise5.Number = 5;
            exercise5.Lecture = "Some math";
            exercise5.Teacher = teacher4;
            exercise5.Student = student2;
            exercise5.Course = course3;
            db.Add(exercise5);
            
            StudentCourseEntity joinedStudCourse = new StudentCourseEntity()
            {
                Students = student0,
                Courses = course,
            };
            db.Add(joinedStudCourse);
            joinedStudCourse = new StudentCourseEntity()
            {
                Students = student1,
                Courses = course,
            };
            db.Add(joinedStudCourse);
            joinedStudCourse = new StudentCourseEntity()
            {
                Students = student2,
                Courses = course,
            };

            
            
            db.Add(joinedStudCourse);
        
            db.SaveChanges();
        }

    }
}