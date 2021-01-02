using Ganjeh.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Ganjeh.Infrastructure.Configurations
{
    public static class RegionEntityConfiguration
    {
        public static void Config(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RegionCountry>()
                .HasIndex(b => b.Title)
                .IsUnique();
        }
    }
}