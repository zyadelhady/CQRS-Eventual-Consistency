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
    class InsertEnrollmentHandler : IRequestHandler<InsertEnrollment, bool>
	{

		private readonly DataContext _context;

		public InsertEnrollmentHandler(DataContext context)
		{
			_context = context;
		}


		public async Task<bool> Handle(InsertEnrollment request, CancellationToken cancellationToken)
		{
			Console.WriteLine("*** Enroll HANDLER ***");

			var course = await _context.Courses.FindAsync(request.EnrollDto.CourseID);
			var student = await _context.Students.FindAsync(request.EnrollDto.StudentID);
			if (student == null)
			{
				student = new Student(request.EnrollDto.StudentID, "", "");
				await _context.Students.AddAsync(student);
			}
			if (string.IsNullOrEmpty(student.CourseOneName))
			{
				student.CourseOneName = course.Name;
				student.CourseOneCredits = course.Credits;
				student.CourseOneGrade = request.EnrollDto.Grade;
			}
			else if (string.IsNullOrEmpty(student.CourseTwoName))
			{
				student.CourseTwoName = course.Name;
				student.CourseTwoCredits = course.Credits;
				student.CourseTwoGrade = request.EnrollDto.Grade;
			}
			student.NumberOfEnrollments++;
			return await _context.SaveAllAsync();  
		}
	}
}
