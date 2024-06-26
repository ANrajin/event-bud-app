﻿using EventBud.Domain._Shared.Results;
using MediatR;

namespace EventBud.Application.Abstractions.Requests;

public interface IQueryHandler<in TQuery, TResponse> : IRequestHandler<TQuery, IResult<TResponse>>
    where TQuery : IQuery<TResponse>
{
}
