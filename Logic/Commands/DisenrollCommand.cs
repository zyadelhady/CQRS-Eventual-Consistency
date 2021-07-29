using Logic.DTOs;
using Logic.utils;
using MediatR;

namespace Logic.Commands
{
    public record DisenrollCommand(DisenrollDto DisenrollDto) : IRequest<Result>; 
}
