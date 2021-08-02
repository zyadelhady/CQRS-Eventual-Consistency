using MediatR;
using Read.Commands;
using Read.Data;
using System.Threading;
using System.Threading.Tasks;

namespace Read.Handlers
{
    class InsertStudentHandler : IRequestHandler<InsertStudent, bool>
    {
        private readonly DataContext _dataContext;

        public InsertStudentHandler(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<bool> Handle(InsertStudent request, CancellationToken cancellationToken)
        {
            var student = await _dataContext.Students.FindAsync(request.student.Id);
            if (student == null)
            {
                student = new Student(request.student.Id, request.student.Email, request.student.Name);
                await _dataContext.Students.AddAsync(student);
            }
            else
            {
                student.Name = request.student.Name;
                student.Email = request.student.Email;   
            }

            return await _dataContext.SaveAllAsync();
        }
    }
}
