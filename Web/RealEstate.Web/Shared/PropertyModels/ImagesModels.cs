using RealEstate.Data.Models.DatabaseModels;
using RealEstate.Services.Mapping;

namespace RealEstate.Web.Shared.PropertyModels
{
    public class ImagesModels : IMapFrom<ImagesUrls>
    {
        public string? Url { get; set; }

        public string? PropertyId { get; set; }
    }
}
