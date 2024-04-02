using FintechService.Domain;
using System.Threading.Tasks;

namespace FintechService.Repository
{
    public class DbContextHandler : IDbContextHandler
    {
        private readonly FintechServiceDbContext _dbContext;

        public DbContextHandler(FintechServiceDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}