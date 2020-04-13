using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DabAflevering2.Entities
{
    public class StudentEntity
    {
        [Key]
        public int AuId { get; set; }
        [Required]
        public string Name { get; set; }

        //Nav props:
        public ICollection<StudentCourseEntity> Courses { get; set; }
        public ICollection<ExerciseEntity> Exercises { get; set; }
        public ICollection<AssignmentStudentEntity> Assignments { get; set; }

    }
}