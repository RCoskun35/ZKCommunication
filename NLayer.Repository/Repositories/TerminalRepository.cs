using Microsoft.EntityFrameworkCore;
using NLayer.Core;
using NLayer.Core.Repositories;

namespace NLayer.Repository.Repositories
{
    public class TerminalRepository : GenericRepository<Terminal>, ITerminalRepository
    {
        public TerminalRepository(AppDbContext context) : base(context)
        {
        }

        
    }
}
