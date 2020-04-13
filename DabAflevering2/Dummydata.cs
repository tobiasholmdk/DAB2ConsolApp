using Dab_aflevering_2.DBContext;
using Dab_aflevering_2.Entities;

namespace DabAflevering2
{
    public class DummyData
    {
        public void InsertDummyData()
        {
            using var db = new DabDBContext();
            
            TeacherEntity teacher = new TeacherEntity();
            teacher.Name = "Teacher1";
            db.Add(teacher);
 
            teacher = new TeacherEntity();
            teacher.Name = "Teacher2";
            db.Add(teacher);
                    
            StudentEntity student = new StudentEntity();
            student.Name = "Student1";
            db.Add(student);
                    
            student = new StudentEntity();
            student.Name = "Student2";
            db.Add(student);
                    
            db.SaveChanges();
        }

    }
}