using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Dab_aflevering_2.Contracts;

namespace Dab_aflevering_2.Entities
{
    public class AssignmentStudentEntity
    {
        [Key]
        public int AssignmentId { get; set; }
        public AssignmentEntity Assignments { get; set; }
        
        public int StudentAuId { get; set; }
        public StudentEntity Students { get; set; }

        public bool HelpWith { get; set; }
    }
}
