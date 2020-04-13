using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DabAflevering2.Entities
{
    public class AssignmentEntity 
    {
        [Key]
        public int AssignmentId { get; set; }
        
        public TeacherEntity Teacher { get; set; }
        
        public int CourseId { get; set; }
        public CourseEntity Course { get; set; }
        
        public ICollection<AssignmentStudentEntity> Students { get; set; }
    }
}