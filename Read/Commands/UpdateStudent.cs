using MediatR;
using Read.utils;

namespace Read.Commands
{
    public record UpdateStudent(StudentJson student) : IRequest<bool>;
}
