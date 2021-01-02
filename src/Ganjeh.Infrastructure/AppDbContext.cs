using Ganjeh.Domain.Entities;
using Ganjeh.Infrastructure.Configurations;
using Microsoft.EntityFrameworkCore;

namespace Ganjeh.Infrastructure
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            RegionEntityConfiguration.Config(modelBuilder);
        }
        public DbSet<RegionCountry> RegionCountries { get; set; }
    }
}