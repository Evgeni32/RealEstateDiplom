using RealEstate.Web.Shared.DistrictModels;

namespace RealEstate.Services
{
    public interface IDistrictService
    {
        public Task<string> Create(DistrictInputModel model);
        public Task<bool> Update(DistrictUpdateModel model);

        public Task<DistrictViewModel> Get(string id);
        public Task Delete(string id);
    }
}
