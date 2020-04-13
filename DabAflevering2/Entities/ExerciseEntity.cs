using System.ComponentModel.DataAnnotations;

namespace DabAflevering2.Entities
{
    public class ExerciseEntity 
    {
        public int Id { get; set; }
        [Required]
        public int Number { get; set; }
        [Required]
        public string Lecture { get; set; }
        public string? HelpWhere { get; set; }
        
        // Nav props
        public TeacherEntity Teacher { get; set; }
        public StudentEntity Student { get; set; }
        public CourseEntity Course { get; set; }
    }
}