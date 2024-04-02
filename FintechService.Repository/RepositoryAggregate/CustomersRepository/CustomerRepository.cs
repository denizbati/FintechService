using FintechService.ApiContract;
using FintechService.Domain.PFintechServiceAggregate;
using FintechService.Domain.PFintechServiceAggregate.Repositories.CustomerRepository;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace FintechService.Repository.RepositoryAggregate.CustomersRepository
{
    internal class CustomerRepository : GenericRepository<Customer>, ICustomerRepository
    {


        public CustomerRepository(FintechServiceDbContext context) : base(context)
        {

        }
        public async Task CreateCustomer(Customer input, CancellationToken cancellationToken)
        {
            await _entities.AddAsync(input, cancellationToken);
        }
        public async Task<List<Customer>> GetCustomerWithIdentityNumber(long identityNumber, CancellationToken cancellationToken)
        {
            return await _entities.Where(s => s.IdentityNumber == identityNumber).AsQueryable().ToListAsync(cancellationToken);
        }
        public Task<int> SaveChangeAsync(CancellationToken cancellationToken)
        {
            return _dbContext.SaveChangesAsync(cancellationToken);

        }

    }
}
