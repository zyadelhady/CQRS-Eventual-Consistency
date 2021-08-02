using MediatR;
using Read.Commands;
using Read.Data;
using System.Threading;
using System.Threading.Tasks;

namespace Read.Handlers
{

    public class UpdateEnrollmentHandler : IRequestHandler<UpdateEnrollment, bool>
    {
        private readonly DataContext _context;

        public UpdateEnrollmentHandler(DataContext context)
        {
            _context = context;
        }
        public async Task<bool> Handle(UpdateEnrollment request, CancellationToken cancellationToken)
        {
            var student = await _context.Students.FindAsync(request.After.StudentID);
            var beforeCourse = await _context.Courses.FindAsync(request.Before.CourseID);
            var afterCourse = await _context.Courses.FindAsync(request.After.CourseID);
            if (student.CourseOneName == beforeCourse.Name)
            {
                student.CourseOneName = afterCourse.Name;
                student.CourseOneCredits = afterCourse.Credits;
                student.CourseOneGrade = request.After.Grade;
            }
            else if (student.CourseTwoName == beforeCourse.Name)
            {
                student.CourseTwoName = afterCourse.Name;
                student.CourseTwoCredits = afterCourse.Credits;
                student.CourseTwoGrade = request.After.Grade;
            }
            return await _context.SaveAllAsync();
        }
    }
}  

