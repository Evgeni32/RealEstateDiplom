using RealEstate.Data.Models.Enumerations;

namespace RealEstate.Web.Shared.PropertyModels
{
    public class PropertyUpdateModalModel
    {
        public string? PropertyId { get; set; }

        public double? Price { get; set; }

        public double? Area { get; set; }

        public int? Floor { get; set; }

        public string? Heating { get; set; }

        public string? FurnishedLevel { get; set; }

        public string? Description { get; set; }

        public string? Statute { get; set; }

        public Status? Status { get; set; }

        public string? PropertyTypeId { get; set; }
    }
}
