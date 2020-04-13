using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using DabAflevering2.Contracts;

namespace DabAflevering2.Entities
{
    public class StudentEntity
    {
        [Key]
        public int AuId { get; set; }
        [Required]
        public string Name { get; set; }

        //Nav props:
        public ICollection<CourseEntity> Courses { get; set; }
        public ICollection<ExerciseEntity> Exercises { get; set; }
        public ICollection<AssignmentStudentEntity> Assignments { get; set; }

    }
}