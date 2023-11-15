using FluentValidation;

namespace Geo.Api.Application.Rectangle.SearchQuery;

public static class Validators
{
    public class SearchRequestValidator : AbstractValidator<SearchRequest>
    {
        public SearchRequestValidator()
        {
            RuleFor(request => request.X)
                .InclusiveBetween(0, 1000).WithMessage("X coordinate must be between 0 and 1000.");

            RuleFor(request => request.Y)
                .InclusiveBetween(0, 1000).WithMessage("Y coordinate must be between 0 and 1000.");

            RuleFor(request => request.Width)
                .InclusiveBetween(1,100).WithMessage("Width must be between 0 and 100.");

            RuleFor(request => request.Height)
                .InclusiveBetween(1,100).WithMessage("Height must be between 0 and 100.");
        }
    }
}