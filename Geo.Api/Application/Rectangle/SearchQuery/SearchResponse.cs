namespace Geo.Api.Application.Rectangle.SearchQuery;

public record SearchResponse(int Count,List<RectangleResponse> Items);
