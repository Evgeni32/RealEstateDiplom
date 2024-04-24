using RealEstate.Data.Models.ApplicationModels;
using RealEstate.Data.Models.Enumerations;

namespace RealEstate.Data.Models.DatabaseModels
{
    // таблица за базата данни
    public class Property : BaseDeletableModel<string>
    {
        public Property()
        {
            this.PropertyInspections = new HashSet<PropertyInspection>();
            this.ImagesUrls = new HashSet<ImagesUrls>();
        }
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

        public District? District { get; set; }

        public string? PropertyTypeId { get; set; }

        public PropertyType? PropertyType { get; set; }

        public string? UserId { get; set; }
        public string ApplicationUserId { get; set; }

        public ApplicationUser? ApplicationUser { get; set; }

        public virtual ICollection<ImagesUrls> ImagesUrls { get; set; }

        public virtual ICollection<PropertyInspection> PropertyInspections { get; set; }
    }
}
