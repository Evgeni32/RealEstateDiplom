using RealEstate.Web.Shared;
using RealEstate.Web.Shared.InputModels;
using RealEstate.Web.Shared.PropertyModels;

namespace RealEstate.Services
{
    public interface IPropertyService
    {
        public Task Recover(string id);
        public Task<IEnumerable<PropertyViewModel>> SearchPropertiesByType(string input);
        public Task<IEnumerable<PropertyViewModel>> SearchProperties(IndexInputModel model);
        public Task<string> Create(PropertyInputModel model);

        public Task<bool> Delete(string properyId);

        public Task<PropertyViewModel> Get(string properyId);
        Task<IEnumerable<T>> GetTopProperties<T>(int? count = null);
        public Task UpdateById(PropertyUpdateModalModel model);
        public Task Update (PropertyUpdateModel model);
        Task<IEnumerable<T>> GetAll<T>(string distinctId);
        Task<IEnumerable<T>> GetAll<T>();
        public Task Requsts(RequestModel model);
        public Task Message(MessageModel model);
    }
}
