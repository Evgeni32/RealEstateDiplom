using RealEstate.Data.Models.DatabaseModels;
using RealEstate.Services.Mapping;

namespace RealEstate.Web.Shared.PropertyTypeModels
{
    public class PropertyTypeViewModel : IMapFrom<PropertyType>
    {
        public string? Id { get; set; }

        public string? Name { get; set; }
    }
}
