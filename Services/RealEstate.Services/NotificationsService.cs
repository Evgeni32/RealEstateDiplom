using Microsoft.EntityFrameworkCore;
using RealEstate.Data;
using RealEstate.Data.Models.DatabaseModels;
using RealEstate.Services.Mapping;

namespace RealEstate.Services
{
    public class NotificationsService : INotificationService
    {
        private readonly ApplicationDbContext dbContext;
        public NotificationsService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<IEnumerable<T>> GetAllRequests<T>(int? count = null)
        {
            IQueryable<Requests> query = this.dbContext.Requests.Where(x => x.IsDeleted == false);
            if (count.HasValue)
            {
                query = query.Take(count.Value);
            }
           
            var result = await query.To<T>().ToListAsync();
            return result;
        }
        public async Task<IEnumerable<T>> GetAllMessages<T>(int? count = null)
        {
            IQueryable<Messages> query = this.dbContext.Messages.Where(x => x.IsDeleted == false);
            if (count.HasValue)
            {
                query = query.Take(count.Value);
            }

            var result = await query.To<T>().ToListAsync();
            return result;
        }
    }
}
