using Geo.Api.Extensions;
using NetTopologySuite.Geometries;

namespace Geo.Api.Application.Rectangle.CreateCommand;

public static partial class Mapper
{
    public static Polygon MapToGeometry(this CreateRequest source)
    {
        return RectangleExtension.CreateNetTopologySuitePolygon(source.X,source.Y,source.Width,source.Height);
    }
}