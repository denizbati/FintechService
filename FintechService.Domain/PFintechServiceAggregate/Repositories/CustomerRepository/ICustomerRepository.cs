using System.Drawing;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace FintechService.Domain.PFintechServiceAggregate.Repositories.CustomerRepository

{
    public interface ICustomerRepository : IGenericRepository<Customer>
    {
        Task CreateCustomer(Customer input, CancellationToken cancellationToken);
        Task<List<Customer>> GetCustomerWithIdentityNumber(long identityNumber, CancellationToken cancellationToken);

        Task<int> SaveChangeAsync(CancellationToken cancellationToken);

    }
}
