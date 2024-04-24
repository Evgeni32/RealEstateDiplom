using System.ComponentModel.DataAnnotations;

namespace RealEstate.Web.Shared.PropertyTypeModels
{
    public class PropertyTypeUpdateModel
    {
        [Required]
        public string? PropertyTypeId { get; set; }

        [Required]
        public string? Name { get; set; }

        [Required]
        public string? DistrictId { get; set; }
    }
}
