using EventBud.Domain._Shared;
using MediatR;

namespace EventBud.Application.Abstractions.Requests;

public interface ICommandHandler<in TCommand> : IRequestHandler<TCommand, IResult>
    where TCommand : ICommand
{
}

public interface ICommandHandler<in TCommand, TResponse> : IRequestHandler<TCommand, IResult<TResponse>>
    where TCommand : ICommand<TResponse>
{
}
