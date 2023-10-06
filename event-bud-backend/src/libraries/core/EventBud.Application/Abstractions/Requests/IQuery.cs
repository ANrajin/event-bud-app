using EventBud.Domain._Shared;
using MediatR;

namespace EventBud.Application.Abstractions.Requests;

public interface IQuery<out TResponse> : IRequest<IResult<TResponse>>
{
}
