using RealEstate.Data.Models.ApplicationModels;

namespace RealEstate.Data.Models.DatabaseModels
{
    public class Messages : BaseDeletableModel<string>
    {
        public string? Regarding { get; set; }

        public string? Names { get; set; }

        public string? Email { get; set; }

        public string? Message { get; set; }
    }
}
