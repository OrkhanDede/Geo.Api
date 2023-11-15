using Geo.Api.Application.Configurations.Queries;

namespace Geo.Api.Application.Rectangle.SearchQuery;

public class SearchQuery : IQuery<SearchResponse>
{
    public SearchRequest Request { get; }

    public SearchQuery(SearchRequest request)
    {

        Request = request ?? throw new ArgumentNullException(nameof(request));
    }
}