using Logic.DTOs;
using Logic.utils;
using MediatR;

namespace Logic.Commands
{
    public record TransferCommand(TransferDto TransferDto) : IRequest<Result>;
}
