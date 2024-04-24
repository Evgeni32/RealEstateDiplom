using RealEstate.Data.Models.ApplicationModels;
using RealEstate.Data.Models.DatabaseModels;
using RealEstate.Data.Models.Enumerations;
using RealEstate.Services.Mapping;

namespace RealEstate.Web.Shared.PropertyModels
{
    // това е модел за цруд операция ориентирай се по имената input e за записване в базата а view за фронтенда
    public class PropertyViewModel : IMapFrom<Property>
    {
        public string? Id { get; set; }

        public string? Code { get; set; }

        public double? Price { get; set; }

        public double? Area { get; set; }

        public int? Floor { get; set; }

        public string? Heating { get; set; }

        public string? FurnishedLevel { get; set; }

        public string? Description { get; set; }

        public int? Seen { get; set; }

        public string? Statute { get; set; }

        public Status? Status { get; set; }

        public bool IsBuying { get; set; }

        public bool IsSolded { get; set; }

        public bool IsRental { get; set; }

        public string? DistrictId { get; set; }

        public string? DistrictName { get; set; }

        public string? PropertyTypeId { get; set; }

        public string? PropertyTypeName { get; set; }

        public string? TownName { get; set; }

        public IEnumerable<ImagesModels>? ImagesUrls { get; set; }
    }
}
