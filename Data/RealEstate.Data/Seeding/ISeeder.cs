namespace RealEstate.Data.Seeding
{
    //интерфейс  за сийдване на данни
    public interface ISeeder
    {
        Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider);
    }
}
