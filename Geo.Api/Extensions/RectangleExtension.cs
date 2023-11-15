using NetTopologySuite;
using NetTopologySuite.Geometries;

namespace Geo.Api.Extensions
{
    public static class RectangleExtension
    {
        public static Polygon CreateNetTopologySuitePolygon(double x, double y, double width, double height)
        {
            var geometryFactory = NtsGeometryServices.Instance.CreateGeometryFactory(srid: 4326);

            var bottomLeftEdge = new Coordinate(x, y);
            var bottomRightEdge = new Coordinate(x + width, y);
            var topLeftEdge = new Coordinate(x, y + height);
            var topRightEdge =
                new Coordinate(x + width, y + height);

            var points = new List<Coordinate>()
            {
                bottomLeftEdge,
                bottomRightEdge,
                topRightEdge,
                topLeftEdge,
                bottomLeftEdge,// A LinearRing requires 4 coordinates and 1st and last coordinate must be equal!
            };
            var linearRing = geometryFactory.CreateLinearRing(points.ToArray());
            var polygon= geometryFactory.CreatePolygon(linearRing);

            return polygon;
        }
    }
}
