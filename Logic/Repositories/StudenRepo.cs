using API.Data;
using Logic.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Repositories
{
    public class StudenRepo
    {
        private readonly DataContext _context;

        public StudenRepo(DataContext context)
        {
            _context = context;
        }

        public async Task<Student> GetById(int id)
        {
            return await _context.Students.FindAsync(id); 
        }
    }
}
