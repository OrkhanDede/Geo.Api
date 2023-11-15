using Geo.Api.Application.Configurations.Queries;
using Geo.Api.DataAccess;
using Geo.Api.Exceptions;
using Microsoft.EntityFrameworkCore;


namespace Geo.Api.Application.Rectangle.SearchQuery;

public class SearchQueryHandler : IQueryHandler<SearchQuery, SearchResponse>
{
    private readonly ApplicationDbContext _context;

    public SearchQueryHandler(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<SearchResponse> Handle(SearchQuery query, CancellationToken cancellationToken)
    {
        var request = query.Request;
        var validator = new Validators.SearchRequestValidator();
        var result = validator.Validate(request);

        if (!result.IsValid)
        {
            throw new ValidationException(result);
        }

        var polygon = request.MapToPolygon();

        var data = await _context.Rectangles
            .Where(r => r.Polygon.Within(polygon))
            .ToListAsync(CancellationToken.None);

        var response = data.Select(c => c.MapToRectangleResponse()).ToList();

        return new SearchResponse(Items: response, Count: response.Count);
    }
}