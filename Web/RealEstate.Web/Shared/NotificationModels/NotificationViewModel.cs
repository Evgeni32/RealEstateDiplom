namespace RealEstate.Web.Shared.NotificationModels
{
    public class NotificationViewModel
    {
        public IEnumerable<MessageViewModel>? Messages { get; set; }

        public IEnumerable<RequestViewModel>? Requests { get; set; }
    }
}
