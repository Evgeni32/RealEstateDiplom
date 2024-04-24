using RealEstate.Web.Shared;

namespace RealEstate.Services
{
    public interface ITownService
    {
        Task<IEnumerable<T>> GetAll<T>(int? count = null, bool orderByDesc = false);
        Task<string> GetTownByDistrictId(string districtId);
        public Task<string> GetTownId(string id);
        public Task<TownViewModel> GetTown(string townId);

        public Task<string> Create(string name);

        public Task Update(string townId, string name);

        public Task<bool> Delete(string townId);
    }
}
