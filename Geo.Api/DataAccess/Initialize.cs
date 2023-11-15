using Geo.Api.Extensions;
using Microsoft.EntityFrameworkCore;

namespace Geo.Api.DataAccess;

public static class Initialize
{
    public static async Task SeedAsync(ApplicationDbContext context)
    {
        await SeedRectangle(context);
    }

    private static async Task SeedRectangle(ApplicationDbContext context)
    {
        var guidList = GenerateGuidList();

        var dbData = await context.Rectangles
            .Where(c => guidList.Contains(c.Id)).Select(c => c.Id)
            .ToListAsync();


        var excluded = guidList.Except(dbData).ToList();

        if (excluded.Any())
        {
            var i = 1;
            var rectangleList = new List<Entities.Rectangle>();
            foreach (var guid in excluded)
            {
                var x = i;
                var y = i;
                var width = x + 5;
                var height = y + 5;

                var polygon = RectangleExtension.CreateNetTopologySuitePolygon(x, y, width, height);
                rectangleList.Add(new Entities.Rectangle()
                {
                    Id = guid,
                    Polygon = polygon
                });

                i++;
            }

            await context.Rectangles.AddRangeAsync(rectangleList);
            await context.SaveChangesAsync();
        }
    }

    private static List<Guid> GenerateGuidList()
    {
        var guilds = new List<Guid>();
        for (var i = 1; i <= 200; i++)
        {
            var count = CountDigits(i);
            if (count == 1)
            {
                guilds.Add(new Guid($"00000000-0000-0000-0000-00000000000{i}"));
            }
            else if (count == 2)
            {
                guilds.Add(new Guid($"00000000-0000-0000-0000-0000000000{i}"));
            }

            else if (count == 3)
            {
                guilds.Add(new Guid($"00000000-0000-0000-0000-000000000{i}"));
            }
            else
            {
                break;
            }
        }

        int CountDigits(int number)
        {
            return Math.Abs(number).ToString().Length;
        }


        return guilds;
    }
}