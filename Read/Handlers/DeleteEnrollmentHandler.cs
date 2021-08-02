using MediatR;
using Read.Commands;
using Read.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Read.Handlers
{
    class DeleteEnrollmentHandler : IRequestHandler<DeleteEnrollment, bool>
    {

		private readonly DataContext _context;

		public DeleteEnrollmentHandler(DataContext context)
        {
			_context = context;
		}

        public async Task<bool> Handle(DeleteEnrollment request, CancellationToken cancellationToken)
		{
			var student = await _context.Students.FindAsync(request.Dto.StudentID);
			var course = await _context.Courses.FindAsync(request.Dto.CourseID);
			if (student.CourseOneName == course.Name)
			{
				student.CourseOneName = null;
				student.CourseOneCredits = 0;
				student.CourseOneGrade = 0;
			}
			else if (student.CourseTwoName == course.Name)
			{  
				student.CourseTwoName = null;
				student.CourseTwoCredits = 0;
				student.CourseTwoGrade = 0;
			}
			student.NumberOfEnrollments--;
			return await _context.SaveAllAsync();
		}
	}
}
