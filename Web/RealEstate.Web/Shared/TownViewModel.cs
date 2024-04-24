using RealEstate.Data.Models.DatabaseModels;
using RealEstate.Services.Mapping;
using RealEstate.Web.Shared.DistrictModels;

namespace RealEstate.Web.Shared
{
    public class TownViewModel : IMapFrom<Town>
    {
        public string? Id { get; set; }
        public string? Name { get; set; }

        public  IEnumerable<DistrictViewModel>? Districts { get; set; }


    }
}
