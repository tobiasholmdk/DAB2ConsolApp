using Dab_aflevering_2.Contracts;

namespace Dab_aflevering_2.Entities
{
    public class ExerciseEntity : IEntity
    {
        public int Id { get; set; }
        public string Number { get; set; }
        public string Lecture { get; set; }
        public string HelpWhere { get; set; }
        
        // Nav props
        public TeacherEntity Teacher { get; set; }
        public StudentEntity Student { get; set; }
    }
}