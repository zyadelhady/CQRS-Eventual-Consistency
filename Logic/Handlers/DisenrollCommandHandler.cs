using API.Data;
using Logic.Commands;
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
    class DisenrollCommandHandler : IRequestHandler<DisenrollCommand, Result>
    {
        private readonly DataContext _context;

        public DisenrollCommandHandler(DataContext context)
        {
            _context = context;
        }
        public async Task<Result> Handle(DisenrollCommand request, CancellationToken cancellationToken)
        {
            if (string.IsNullOrWhiteSpace(request.DisenrollDto.Comment)) return ResultFactory.Fail("Comment is required.");

            var student = await _context.Students.FindAsync(request.DisenrollDto.StudentId);
            if (student == null) return ResultFactory.Fail("No student with that id.");

            var enrollment = student.GetEnrollment(request.DisenrollDto.EnrollmentNumber);
            if (enrollment == null) return ResultFactory.Fail("No enrollment with that number.");

            student.RemoveEnrollment(enrollment, request.DisenrollDto.Comment);
            await _context.SaveAllAsync();

            return ResultFactory.Ok();
        }
    }
}
