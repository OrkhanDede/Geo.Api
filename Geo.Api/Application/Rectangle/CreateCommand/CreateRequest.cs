namespace Geo.Api.Application.Rectangle.CreateCommand;

/// <summary>
/// Represents a create request with rectangle coordinates and dimensions.
/// </summary>
public record CreateRequest
{
    /// <summary>
    /// Gets or sets the X coordinate of the rectangle.
    /// Valid range: 0 to 1000 (inclusive).
    /// </summary>
    public double X { get; set; }

    /// <summary>
    /// Gets or sets the Y coordinate of the rectangle.
    /// Valid range: 0 to 1000 (inclusive).
    /// </summary>
    public double Y { get; set; }

    /// <summary>
    /// Gets or sets the width of the rectangle.
    /// Valid range: 0 to 100 (inclusive).
    /// </summary>
    public double Width { get; set; }

    /// <summary>
    /// Gets or sets the height of the rectangle.
    /// Valid range: 0 to 100 (inclusive).
    /// </summary>
    public double Height { get; set; }
}