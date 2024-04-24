using System.ComponentModel.DataAnnotations;

namespace RealEstate.Web.Shared.DistrictModels
{
    public class DistrictInputModel
    {
        [Required]
        [StringLength(100, ErrorMessage = "Името не може да е по дълго от 100 символа")]
        public string? Name { get; set; }

        [Required]
        public string? TownId { get; set; }
    }
}
