using System.Reflection;
using EventBud.Domain._Shared.Results;
using FluentValidation;
using MediatR;

namespace EventBud.Application.Behaviours;

public class ValidationPipelineBehaviour<TRequest, TResponse> 
    : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
    where TResponse : IResult
{
    private readonly IEnumerable<IValidator<TRequest>> _validators;

    public ValidationPipelineBehaviour(IEnumerable<IValidator<TRequest>> validators)
    {
        _validators = validators;
    }

    public async Task<TResponse> Handle(
        TRequest request, 
        RequestHandlerDelegate<TResponse> next, 
        CancellationToken cancellationToken)
    {
        if (!_validators.Any())
        {
            return await next();
        }

        var errors = _validators.Select(validator => validator.Validate(request))
            .SelectMany(validations => validations.Errors)
            .Where(validationFailure => validationFailure is not null)
            .Select(failure => new Error(failure.PropertyName, failure.ErrorMessage))
            .Distinct()
            .ToList();

        if (errors.Any())
        {
            return CreateValidationResult<TResponse>(errors);
        }

        return await next();
    }

    private static TResult CreateValidationResult<TResult>(IReadOnlyCollection<Error> errors) 
        where TResult : IResult
    {
        if (typeof(TResult) == typeof(IResult))
        {
            return (Result.Failure(errors) is TResult 
                ? (TResult)Result.Failure(errors) : default)!;
        }

        var validationResult = typeof(Result<>)
            .GetGenericTypeDefinition()
            .MakeGenericType(typeof(TResult).GetGenericArguments().First())
            .GetMethod("Failure",
                BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.ExactBinding,
                null,
                new[] { typeof(IReadOnlyCollection<Error>) },
                null)!
            .Invoke(null, new object[] { errors });
        
        return (TResult)validationResult!;
    }
}
