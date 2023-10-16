using EventBud.Domain._Shared.Results;
using MediatR;

namespace EventBud.Application.Abstractions.Requests;

public interface ICommand : IRequest<IResult>
{}

public interface ICommand<out TResponse> : IRequest<IResult<TResponse>>
{
}
