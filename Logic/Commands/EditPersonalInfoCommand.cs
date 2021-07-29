using Logic.DTOs;
using Logic.utils;
using MediatR;


namespace Logic.Commands
{
    public record EditPersonalInfoCommand(PersonalInfoDto PersonalInfoDto) : IRequest<Result>;
}
