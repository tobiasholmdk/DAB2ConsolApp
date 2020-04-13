﻿using System;
using System.Collections.Generic;
 using System.ComponentModel.DataAnnotations;
 using System.Linq;
using System.Threading.Tasks;

 namespace DabAflevering2.Entities
{
    public class StudentCourseEntity
    {
        public int Id { get; set; }
        
        public int StudentAuId { get; set; }
        public StudentEntity Students { get; set; }
        
        public int CourseId { get; set; }
        public CourseEntity Courses { get; set; }
        
        public int Semester { get; set; }
    }
}
