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
    class EditPersonalInfoCommandHandler : IRequestHandler<EditPersonalInfoCommand, Result>
    {
		private readonly DataContext _context;

		public EditPersonalInfoCommandHandler(DataContext context)
		{
			_context = context;
		}
        public async Task<Result> Handle(EditPersonalInfoCommand request, CancellationToken cancellationToken)
        {
			var student = await _context.Students.FindAsync(request.PersonalInfoDto.Id);
			if (student == null) return ResultFactory.Fail("No student with that id.");
			student.Name = request.PersonalInfoDto.Name;
			student.Email = request.PersonalInfoDto.Email;
			await _context.SaveAllAsync();
			return ResultFactory.Ok();
		}
    }
}
