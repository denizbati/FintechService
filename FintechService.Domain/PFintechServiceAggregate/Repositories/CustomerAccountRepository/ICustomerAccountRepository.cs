using System.Threading;
using System.Threading.Tasks;

namespace FintechService.Domain.PFintechServiceAggregate.Repositories.CustomerAccountRepository
{
    public interface ICustomerAccountRepository : IGenericRepository<CustomerAccount>
    {
        Task<int> SaveChangeAsync(CancellationToken cancellationToken);

    }
}
