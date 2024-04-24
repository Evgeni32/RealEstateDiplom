using System.ComponentModel.DataAnnotations;

namespace RealEstate.Web.Shared.PropertyInspectionModels
{
    // това е модел за цруд операция ориентирай се по имената input e за записване в базата а view за фронтенда
    public class PropertyInspectionInputModel
    {
        [Required]
        public string? UserName { get; set; }

        [Required]
        [Phone]
        public string? PhoneNumber { get; set; }

        [Required]
        [EmailAddress]
        public string? Email { get; set; }

        [Required]
        public string? Inquiry { get; set; }

        [Required]
        public string? Date { get; set; }

        [Required]
        public string? Hour { get; set; }

        [Required]
        public string? PropertyId { get; set; }
    }
}
