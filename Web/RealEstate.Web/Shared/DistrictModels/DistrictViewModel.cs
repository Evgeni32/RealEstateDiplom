using RealEstate.Data.Models.DatabaseModels;
using RealEstate.Services.Mapping;
using RealEstate.Web.Shared.PropertyTypeModels;

namespace RealEstate.Web.Shared.DistrictModels
{
    public class DistrictViewModel : IMapFrom<District>
    {
        public string? Id { get; set; }
        public string? Name { get; set; }

        public IEnumerable<PropertyTypeViewModel> PropertyTypeViewModels { get; set; }
    }
}