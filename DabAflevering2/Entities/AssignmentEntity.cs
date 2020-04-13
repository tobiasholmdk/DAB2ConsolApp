using System.Collections.Generic;
using Dab_aflevering_2.Contracts;

namespace DabAflevering2.Entities
{
    public class AssignmentEntity
    {
        public int Id { get; set; }
        
        // Nav props
        
        public TeacherEntity Teacher { get; set; }
        public CourseEntity Course { get; set; }
        public ICollection<AssignmentStudentEntity> Students { get; set; }
    }
}