using Logic.DTOs;
using Logic.utils;
using MediatR;

namespace Logic.Commands
{
    public record EnrollCommand(EnrollDto EnrollDto) : IRequest<Result>;
}
