using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DabAflevering2.Entities
{
    public class CourseEntity
    {
        [Key]
        public int CourseId { get; set; }
        [Required]
        public string Name { get; set; }

        public ICollection<StudentCourseEntity> Students { get; set; }
        public ICollection<AssignmentEntity> Assignments { get; set; }
        public ICollection<ExerciseEntity> Exercises { get; set; }
        public ICollection<TeacherEntity> Teachers { get; set; }
    }
}