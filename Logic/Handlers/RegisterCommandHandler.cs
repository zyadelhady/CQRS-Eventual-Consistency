using API.Data;
using Logic.Commands;
using Logic.Entities;
using Logic.utils;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Logic.Handlers
{
    class RegisterCommandHandler : IRequestHandler<RegisterCommand, Result>
    {
        private readonly DataContext _context;

        public RegisterCommandHandler(DataContext context)
        {
            _context = context;
        }
        public  async Task<Result> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            var student = new Student(request.RegisterDto.Name, request.RegisterDto.Email);

            foreach (var courseToRegister in request.RegisterDto.Courses)  
            {
                if (!Enum.IsDefined(typeof(Grade), courseToRegister.Grade)) return ResultFactory.Fail("Grade is invalid");
                var course = await _context.Courses.FindAsync(courseToRegister.CourseId);
                if (course == null) return ResultFactory.Fail("No course with that id.");
                student.Enroll(course, Enum.Parse<Grade>(courseToRegister.Grade));
            }
            await _context.Students.AddAsync(student);
            await _context.SaveAllAsync();
            return ResultFactory.Ok();
        }
    }
}
