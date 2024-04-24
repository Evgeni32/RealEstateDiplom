using RealEstate.Data.Models.DatabaseModels;
using RealEstate.Services.Mapping;

namespace RealEstate.Web.Shared.NotificationModels
{
    public class RequestViewModel : IMapFrom<Requests>
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
