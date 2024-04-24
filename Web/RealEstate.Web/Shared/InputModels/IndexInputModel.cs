using System.ComponentModel.DataAnnotations;

namespace RealEstate.Web.Shared.InputModels
{
    public class IndexInputModel
    {
        [Required(ErrorMessage = "полето е задължително")]
        public string? selectedDistrictId { get; set; }
        [Required(ErrorMessage = "полето е задължително")]
        public int? Floor { get; set; }
        public string? propertyId { get; set; }
        [Required(ErrorMessage = "полето е задължително")]
        public string? selectedTypeId { get; set; }

        [Required(ErrorMessage = "полето е задължително")]
        public string? heating { get; set; }

        [Required(ErrorMessage = "полето е задължително")]
        public string? furnitureLevel { get; set; }

        [Required(ErrorMessage ="полето е задължително")]
        public string? selectedTown { get; set; }

        [Required(ErrorMessage = "полето е задължително")]
        public string? from { get; set; }
        [Required(ErrorMessage = "полето е задължително")]
        public string? to { get; set; }
    }
}
