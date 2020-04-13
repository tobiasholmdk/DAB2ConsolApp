﻿using System;
using System.Collections.Generic;
 using System.ComponentModel.DataAnnotations;
 using System.Linq;
using System.Threading.Tasks;
using Dab_aflevering_2.Contracts;

namespace Dab_aflevering_2.Entities
{
    public class StudentCourseEntity 
    {
        public int Id { get; set; }
        [Required]
        public int StudentAuId { get; set; }
        public StudentEntity Students { get; set; }
        [Required]
        public int CourseId { get; set; }
        public CourseEntity Courses { get; set; }
        [Required]
        public int Semester { get; set; }
    }
}
