using Logic.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Disenrollment> Disenrollments { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<Course> Courses { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);



            builder.Entity<Enrollment>((x) =>
            {
                x.HasOne(e => e.Course)
                .WithMany();

                x.HasOne(e => e.Student)
                .WithMany(s => s.Enrollments)   
                .HasForeignKey(s => s.StudentID);
            });


            builder.Entity<Disenrollment>((x) =>
            {
                x.HasOne(e => e.Course)
                .WithMany();

                x.HasOne(e => e.Student)
                .WithMany(s => s.Disenrollments)
                .HasForeignKey(s => s.StudentID);
                
            });






        }

        public async Task<bool> SaveAllAsync()
        {
            return await SaveChangesAsync() > 0;
        }  
    }
}
