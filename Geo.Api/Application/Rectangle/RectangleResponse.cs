namespace Geo.Api.Application.Rectangle;

/// <summary>
/// Represents the response model for a rectangle, including its coordinates and dimensions.
/// </summary>
public class RectangleResponse
{
    /// <summary>
    /// Gets the unique identifier of the rectangle.
    /// </summary>
    public Guid Id { get; }

    /// <summary>
    /// Gets the origin X coordinate of the rectangle.
    /// </summary>
    public double X { get; }

    /// <summary>
    /// Gets the origin Y coordinate of the rectangle.
    /// </summary>
    public double Y { get; }

    /// <summary>
    /// Gets the width of the rectangle.
    /// </summary>
    public double Width { get; }

    /// <summary>
    /// Gets the height of the rectangle.
    /// </summary>
    public double Height { get; }

    /// <summary>
    /// Gets a list of points representing the coordinates of the rectangle.
    /// </summary>
    public List<Point> Coordinates { get; }

    /// <summary>
    /// Initializes a new instance of the <see cref="RectangleResponse"/> class.
    /// </summary>
    /// <param name="id">The unique identifier of the rectangle.</param>
    /// <param name="x">The X coordinate of the rectangle.</param>
    /// <param name="y">The Y coordinate of the rectangle.</param>
    /// <param name="width">The width of the rectangle.</param>
    /// <param name="height">The height of the rectangle.</param>
    /// <param name="coordinates">A list of points representing the coordinates of the rectangle.</param>
    public RectangleResponse(Guid id, double x, double y, double width, double height, List<Point> coordinates)
    {
        Id = id;
        X = x;
        Y = y;
        Width = width;
        Height = height;
        Coordinates = coordinates;
    }
}
/// <summary>
/// Represents a point with X and Y coordinates.
/// </summary>
public class Point
{
    /// <summary>
    /// Gets the X coordinate of the point.
    /// </summary>
    public double X { get; }

    /// <summary>
    /// Gets the Y coordinate of the point.
    /// </summary>
    public double Y { get; }

    /// <summary>
    /// Initializes a new instance of the <see cref="Point"/> class.
    /// </summary>
    /// <param name="x">The X coordinate of the point.</param>
    /// <param name="y">The Y coordinate of the point.</param>
    public Point(double x, double y)
    {
        X = x;
        Y = y;
    }
}