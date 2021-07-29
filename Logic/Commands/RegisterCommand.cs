using Logic.DTOs;
using Logic.utils;
using MediatR;

namespace Logic.Commands
{
    public record RegisterCommand(RegisterDto RegisterDto) : IRequest<Result>;
}
