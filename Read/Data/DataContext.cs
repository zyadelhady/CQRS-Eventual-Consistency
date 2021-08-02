using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;        
using System.Threading.Tasks;

namespace Read.Data   
{    
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {

        }

       public DbSet<Student> Students { get; set; }
       public DbSet<Course> Courses { get; set; }



        public async Task<bool> SaveAllAsync()
        {
            return await SaveChangesAsync() > 0;
        }  
    }
}
