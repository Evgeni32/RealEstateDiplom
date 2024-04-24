using RealEstate.Data.Models.DatabaseModels;
using RealEstate.Services.Mapping;

namespace RealEstate.Web.Shared.NotificationModels
{
    public class MessageViewModel : IMapFrom<Messages>
    {
        public string? Regarding { get; set; }

        public string? Names { get; set; }

        public string? Email { get; set; }

        public string? Message { get; set; }
    }
}
