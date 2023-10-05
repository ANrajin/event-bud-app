using FluentValidation.Results;

namespace EventBud.Application.Exceptions;

public sealed class ValidationException : Exception
{
    public List<string> ValdationErrors { get; }

    public ValidationException(ValidationResult validationResult)
    {
        ValdationErrors = new List<string>();

        foreach (var validationError in validationResult.Errors)
        {
            ValdationErrors.Add(validationError.ErrorMessage);
        }
    }
}
