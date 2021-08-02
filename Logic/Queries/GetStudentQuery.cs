using Logic.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Queries
{
    public record GetStudentQuery(RequestDto Dto) : IRequest<StudentDto>;
}
