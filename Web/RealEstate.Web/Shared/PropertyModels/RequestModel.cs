

using System.ComponentModel.DataAnnotations;

namespace RealEstate.Web.Shared.PropertyModels
{
    public class RequestModel
    {
        [Required]
        public string? Town { get; set; }
        [Required]
        public string? District { get; set; }
        [Required]
        public string? TypeProperty { get; set; }
        [Required]
        public string? Phone { get; set; }
        [Required]
        public string? Price { get; set; }
        [Required]
        public string? Area { get; set; }
        [Required]
        public string? Email { get; set; }
        [Required]
        public string? Names { get; set; }
    }
}
