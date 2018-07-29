namespace SoftUniClone.Data
{
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using Models;
    
    public class SoftUniCloneDbContext : IdentityDbContext<User>
    {
        public SoftUniCloneDbContext(DbContextOptions<SoftUniCloneDbContext> options)
            : base(options)
        {
        }

        public DbSet<Course> Courses { get; set; }

        public DbSet<CourseInstance> CourseInstances { get; set; }

        public DbSet<Lecture> Lectures { get; set; }

        public DbSet<Resource> Resources { get; set; }

        public DbSet<ResType> ResTypes { get; set; }

        public DbSet<StudentsInCourses> StudentsInCourseses { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<User>()
                .HasMany(u => u.EnrolledCourses)
                .WithOne(ec => ec.Student)
                .HasForeignKey(ec => ec.StudentId);

            builder.Entity<CourseInstance>()
                .HasMany(ci => ci.Students)
                .WithOne(s => s.Course)
                .HasForeignKey(s => s.CourseId);

            builder.Entity<StudentsInCourses>()
                .HasKey(sc => new {sc.CourseId, sc.StudentId});

            base.OnModelCreating(builder);
        }
    }
}
