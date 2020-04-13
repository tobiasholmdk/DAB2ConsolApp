using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DabAflevering2.Entities
{
    public class TeacherEntity
    {
        [Key]
        public int AuId { get; set; }
        [Required]
        public string Name { get; set; }

        // Nav props
        public ICollection<ExerciseEntity> Exercises { get; set; }
        public ICollection<AssignmentEntity> Assignments { get; set; }
        public CourseEntity Course { get; set; }
    }
}