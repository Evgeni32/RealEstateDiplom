using Microsoft.EntityFrameworkCore;
using RealEstate.Data;
using RealEstate.Data.Models.DatabaseModels;
using RealEstate.Services.Mapping;
using RealEstate.Web.Shared.DistrictModels;

namespace RealEstate.Services
{
    public class DistrictService : IDistrictService
    {
        private readonly ITownService townService;
        private readonly ApplicationDbContext dbContext;

        public DistrictService(ITownService townService, ApplicationDbContext dbContext)
        {
            this.townService = townService;
            this.dbContext = dbContext;
        }

        public async Task<string> Create(DistrictInputModel model)
        {
            if (model.TownId != null && model.Name != null)
            {
                var town = await this.townService.GetTownId(model.TownId);
                var district = new District()
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = model.Name,
                    TownId = model.TownId,
                };
               await this.dbContext.Districts.AddAsync(district);
               await this.dbContext.SaveChangesAsync();

                return district.Id;
            }
            throw new InvalidOperationException("Кварталът не може да бъде създаден");
        }
        public async Task<bool> Update(DistrictUpdateModel model)
        {
            if (model.TownId != null && model.districtId != null)
            {
                var district = await this.dbContext.Districts.FirstOrDefaultAsync(x=>x.Id == model.districtId);
                var town = await this.townService.GetTownId(model.TownId);
                district.Name = model.Name;
                district.TownId = model.TownId;
                this.dbContext.Districts.Update(district);
                await this.dbContext.SaveChangesAsync();
                return true;
            }
            return false;
        }
        public async Task<DistrictViewModel> Get(string id)
        {
            var district = await this.dbContext.Districts.Where(x => x.Id == id).To<DistrictViewModel>().FirstOrDefaultAsync();
            return district;
        }
        public async Task Delete(string id)
        {
            var district = await this.dbContext.Districts.FirstOrDefaultAsync(x=>x.Id == id);
            district.IsDeleted = true;
            district.DeletedOn = DateTime.UtcNow;

            this.dbContext.Districts.Update(district);
            await this.dbContext.SaveChangesAsync();
        }
    }
}
