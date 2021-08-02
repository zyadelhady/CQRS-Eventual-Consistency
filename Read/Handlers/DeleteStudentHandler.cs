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
    class DeleteStudentHandler : IRequestHandler<DeleteStudent, bool>
    {
        private readonly DataContext _dataContext;

        public DeleteStudentHandler(DataContext dataContext)
        {
            _dataContext = dataContext; 
        }

        public async Task<bool> Handle(DeleteStudent request, CancellationToken cancellationToken)
        {
            var student = await _dataContext.Students.FindAsync(request.student.Id);
            _dataContext.Students.Remove(student);
            return await _dataContext.SaveAllAsync();
        }
    }  
}
