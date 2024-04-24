

using RealEstate.Web.Shared.PropertyModels;
using RealEstate.Web.Shared.PropertyTypeModels;

namespace RealEstate.Web.Shared.ViewModels
{
    public class IndexViewModel
    {
        public IEnumerable<TownViewModel>? Towns { get; set; }

        public IEnumerable<PropertyTypeViewModel>? Types { get; set; }

        public IEnumerable<PropertyViewModel>? Properties { get; set; }

        public List<PropertiesCountsModel>? countsModels { get; set; }
    }
}