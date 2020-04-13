using System.Collections.Generic;
using DabAflevering2.Contracts;

namespace DabAflevering2.Entities
{
    public class AssignmentEntity 
    {
        [Key]
        public int AssignmentId { get; set; }
        
        // Nav props
        
        public TeacherEntity Teacher { get; set; }
        //public int TeacherId { get; set; }
        public CourseEntity Course { get; set; }
        //public int CourseId { get; set; }
        public ICollection<AssignmentStudentEntity> Students { get; set; }
    }
}