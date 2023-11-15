using NetTopologySuite.Geometries;
using System.ComponentModel.DataAnnotations;

namespace Geo.Api.Entities;

public class Rectangle
{
    [Key] public Guid Id { get; set; }

    public Polygon Polygon { get; set; } = null!;
}