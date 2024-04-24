using RealEstate.Data.Models.DatabaseModels;
using RealEstate.Services.Mapping;

namespace RealEstate.Web.Shared.PropertyInspectionModels
{
    public class PropertyInspectionViewModel : IMapFrom<PropertyInspection>
    {
        public string? UserName { get; set; }

        public string? PhoneNumber { get; set; }

        public string? Email { get; set; }

        public string? Inquiry { get; set; }

        public string? Date { get; set; }

        public string? Hour { get; set; }

        public string? PropertyId { get; set; }
    }
}
