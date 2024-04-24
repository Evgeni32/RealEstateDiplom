using RealEstate.Data.Models.ApplicationModels;

namespace RealEstate.Data.Models.DatabaseModels
{
    public class ImagesUrls : BaseDeletableModel<string>
    {
        public string? Url { get; set; }

        public string? PropertyId { get; set; }

        public Property Property { get; set; }
    }
}
