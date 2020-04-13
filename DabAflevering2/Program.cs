using System;
using Dab_aflevering_2.Contracts;
using DabAflevering2.DBContext;
using DabAflevering2.Entities;
using Dab_aflevering_2.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace DabAflevering2
{
    class Program
    {
        static void Main(string[] args)
        {

            
          //  InsertDummyData();
        }
        /*
        static void InsertDummyData()
        {
            using var db = new DabDBContext();
            
            TeacherEntity teacher = new TeacherEntity();
            teacher.Name = "Teacher1";
            db.Add(teacher);
 
            teacher = new TeacherEntity();
            teacher.Name = "Teacher2";
            db.Add(teacher);
                    
            StudentEntity student = new StudentEntity();
            student.Name = "Student1";
            db.Add(student);
                    
            student = new StudentEntity();
            student.Name = "Student2";
            db.Add(student);
                    
            db.SaveChanges();
        }*/
        
    }
}