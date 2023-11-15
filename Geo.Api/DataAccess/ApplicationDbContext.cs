using Geo.Api.Entities;
using Microsoft.EntityFrameworkCore;

namespace Geo.Api.DataAccess
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {
            
        }

        public DbSet<Rectangle> Rectangles { get; set; }
    }
}
