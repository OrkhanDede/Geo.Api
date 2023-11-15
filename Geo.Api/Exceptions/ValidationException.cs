using System.Net;
using FluentValidation.Results;

namespace Geo.Api.Exceptions;

public class ValidationException : ApplicationException
{
    public List<string> ValidationErrors { get; set; }

    public ValidationException(ValidationResult validationResult, HttpStatusCode statusCode =HttpStatusCode.BadRequest)
    {
        ValidationErrors = new List<string>();
        foreach (var validationError in validationResult.Errors)
        {
            ValidationErrors.Add(validationError.ErrorMessage);
        }
    }
}