using Ganjeh.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Ganjeh.Infrastructure
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)  
        {  
        }

        public DbSet<RegionCountry> RegionCountries { get; set; }
    }
}