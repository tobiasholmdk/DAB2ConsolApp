using DabAflevering2.Entities;
using DabAflevering2.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;


namespace DabAflevering2.DBContext
{
    public class DabDBContext : DbContext
    { 
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        { 
            optionsBuilder.UseSqlServer(@"Data Source=localhost,1433;Database=testB;User ID=SA;Password=Januar2020!;");
        }
        public DbSet<StudentEntity> Students { get; set; }
        public DbSet<TeacherEntity> Teachers { get; set; }
        public DbSet<CourseEntity> Courses { get; set; }
        public DbSet<ExerciseEntity> Exercises { get; set; }
        public DbSet<AssignmentEntity> Assignments { get; set; }
        public DbSet<AssignmentStudentEntity> AssignmentStudents { get; set; }
        public DbSet<StudentCourseEntity> StudentsCourses { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StudentCourseEntity>()
                .HasKey(bc => new { bc.StudentAuId, bc.CourseId });  
            modelBuilder.Entity<StudentCourseEntity>()
                .HasOne(bc => bc.Students)
                .WithMany(b => b.Courses)
                .HasForeignKey(bc => bc.StudentAuId);  
            modelBuilder.Entity<StudentCourseEntity>()
                .HasOne(bc => bc.Courses)
                .WithMany(c => c.Students)
                .HasForeignKey(bc => bc.CourseId);

            modelBuilder.Entity<ExerciseEntity>()
                .HasOne(bc => bc.Course)
                .WithMany(bc => bc.Exercises)
                .HasForeignKey(bc => bc.CourseId);
            modelBuilder.Entity<ExerciseEntity>()
                .HasOne(bc => bc.Student)
                .WithMany(bc => bc.Exercises)
                .HasForeignKey(bc => bc.StudentId);
            modelBuilder.Entity<ExerciseEntity>()
                .HasOne(bc => bc.Teacher)
                .WithMany(bc => bc.Exercises)
                .HasForeignKey(bc => bc.TeacherIds);

            modelBuilder.Entity<AssignmentEntity>()
                .HasOne(bc => bc.Course)
                .WithMany(bc => bc.Assignments)
                .HasForeignKey(bc => bc.CourseId);

            modelBuilder.Entity<AssignmentStudentEntity>()
                .HasKey(bc => new { bc.StudentAuId, bc.AssignmentId });  
            modelBuilder.Entity<AssignmentStudentEntity>()
                .HasOne(bc => bc.Students)
                .WithMany(b => b.Assignments)
                .HasForeignKey(bc => bc.StudentAuId);  
            modelBuilder.Entity<AssignmentStudentEntity>()
                .HasOne(bc => bc.Assignments)
                .WithMany(c => c.Students)
                .HasForeignKey(bc => bc.AssignmentId);
        }
        
        
    }
}
