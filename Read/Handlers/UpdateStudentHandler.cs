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
    class UpdateStudentHandler : IRequestHandler<UpdateStudent, bool>
    {
        private readonly DataContext _dataContext;

        public UpdateStudentHandler(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<bool> Handle(UpdateStudent request, CancellationToken cancellationToken)
        {
            var student = await _dataContext.Students.FindAsync(request.student.Id);
            student.Name = request.student.Name;
            student.Email = request.student.Email;
            return await _dataContext.SaveAllAsync();  
        }
    }
}
