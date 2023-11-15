using NetTopologySuite.Geometries;
using Geo.Api.Extensions;

namespace Geo.Api.Application.Rectangle.SearchQuery;

public static class Mapper
{
    public static Polygon MapToPolygon(this SearchRequest source)
    {
        return RectangleExtension.CreateNetTopologySuitePolygon(source.X, source.Y, source.Width, source.Height);
    }

    public static RectangleResponse MapToRectangleResponse(this Entities.Rectangle source)
    {
        var coordinates = source.Polygon.Coordinates.Select(c => new Point(c.X,c.Y)).ToList();

        var bottomLeftEdge = coordinates[0];
        var bottomRightEdge = coordinates[1];
        var topLeftEdge = coordinates[2];

        var width = bottomRightEdge.X - bottomLeftEdge.X;
        var height = topLeftEdge.Y - bottomLeftEdge.Y;

        return new RectangleResponse(
        
            id:source.Id,
            x: bottomLeftEdge.X,
            y : bottomLeftEdge.Y,
            width: width,
            height : height,
            coordinates : coordinates
        );
    }
}