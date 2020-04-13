using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Dab_aflevering_2.Contracts;

namespace Dab_aflevering_2.Entities
{
    public class CourseEntity
    {
        public int Id { get; set; }
        [Required]
        public int CourseId { get; set; }
        [Required]
        public string Name { get; set; }

        // Nav Props
        public ICollection<StudentCourseEntity> Students { get; set; }
        public ICollection<AssignmentEntity> Assignments { get; set; }
        public ICollection<TeacherEntity> Teachers { get; set; }
    }
}