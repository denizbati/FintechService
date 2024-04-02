using FintechService.Domain.PFintechServiceAggregate;
using FintechService.Domain.PFintechServiceAggregate.Repositories.CustomerAccountRepository;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace FintechService.Repository.RepositoryAggregate.CustomerAccountRepository
{
    internal class CustomerAccountRepository : GenericRepository<CustomerAccount>, ICustomerAccountRepository
    {
        private readonly DbContext _dbContext;


        public CustomerAccountRepository(FintechServiceDbContext context) : base(context)
        {
            _dbContext = context;

        }
        public Task<int> SaveChangeAsync(CancellationToken cancellationToken)
        {
            return _dbContext.SaveChangesAsync(cancellationToken);
        }

    }
}
