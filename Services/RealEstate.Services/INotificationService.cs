namespace RealEstate.Services
{
    public interface INotificationService
    {
        Task<IEnumerable<T>> GetAllRequests<T>(int? count = null);

        Task<IEnumerable<T>> GetAllMessages<T>(int? count = null);
    }
}
