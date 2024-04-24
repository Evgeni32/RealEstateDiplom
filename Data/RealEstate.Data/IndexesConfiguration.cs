using Microsoft.EntityFrameworkCore;
using RealEstate.Data.Models.BaseDeletableModels;

namespace RealEstate.Data
{
    // индекси за това което е изтрито да не се трие наистина
    internal static class IndexesConfiguration
    {
        public static void Configure(ModelBuilder modelBuilder)
        {
            var deletableEntityTypes = modelBuilder.Model
                .GetEntityTypes()
                .Where(et => et.ClrType != null && typeof(IDeletable).IsAssignableFrom(et.ClrType));
            foreach (var deletableEntityType in deletableEntityTypes)
            {
                modelBuilder.Entity(deletableEntityType.ClrType).HasIndex(nameof(IDeletable.IsDeleted));
            }
        }
    }
}
