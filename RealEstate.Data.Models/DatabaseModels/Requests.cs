using RealEstate.Data.Models.ApplicationModels;

namespace RealEstate.Data.Models.DatabaseModels
{
    public class Requests : BaseDeletableModel<string>
    {
        public string? Town { get; set; }

        public string? District { get; set; }

        public string? TypeProperty { get; set; }

        public string? Phone { get; set; }

        public string? Price { get; set; }

        public string? Area { get; set; }

        public string? Email { get; set; }

        public string? Names { get; set; }

        public bool? IsView { get; set; }
    }
}
