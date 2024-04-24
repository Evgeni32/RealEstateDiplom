using System.ComponentModel.DataAnnotations;

namespace RealEstate.Web.Shared.PropertyTypeModels
{
    public class PropertyTypeInputModel
    {
        [Required]
        public string? Name { get; set; }

        [Required]
        public string? DistrictId { get; set; }
    }
}
