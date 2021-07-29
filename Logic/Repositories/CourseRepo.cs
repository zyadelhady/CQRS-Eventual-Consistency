using API.Data;
using Logic.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Repositories
{
    class CourseRepo
    {
        private readonly DataContext _context;

        public CourseRepo(DataContext context)
        {
            _context = context;
            _context = context;
        }

        public async Task<Course> GetByName(string name)
        {
            return await _context.Courses.SingleOrDefaultAsync(x => x.Name == name);
        }
    }
}
