using Microsoft.EntityFrameworkCore;
using NLayer.Core;
using NLayer.Core.Repositories;

namespace NLayer.Repository.Repositories
{
    public class EventDataRepository : GenericRepository<EventData>, IEventDataRepository
    {
        public EventDataRepository(AppDbContext context) : base(context)
        {
        }

        
    }
}
