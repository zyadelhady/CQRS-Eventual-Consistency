using MediatR;
using Read.utils;

namespace Read.Commands
{
    public record DeleteEnrollment(EnrollJson Dto) : IRequest<bool>;

}
