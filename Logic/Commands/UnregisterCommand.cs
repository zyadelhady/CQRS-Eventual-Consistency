using Logic.DTOs;
using Logic.utils;
using MediatR;

namespace Logic.Commands
{
    public record UnregisterCommand(UnregisterDto UnregisterDto) : IRequest<Result>;
}
