using RealEstate.Web.Shared.PropertyInspectionModels;

namespace RealEstate.Services
{
    //интерфейс който ни задължава да използваме методите
    public interface IPropertyInspectionService
    {

        public Task Create(PropertyInspectionInputModel model);
        public Task<PropertyInspectionViewModel> Get(string id);
        public Task<string> Update(string id);
        public Task Delete(string id);
    }
}
