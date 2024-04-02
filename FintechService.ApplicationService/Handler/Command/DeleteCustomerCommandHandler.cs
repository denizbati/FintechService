using FintechService.ApiContract;
using FintechService.ApiContract.Response.Query;
using FintechService.Domain.PFintechServiceAggregate.Repositories.CustomerRepository;
using FintechService.Request.Command;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FintechService.ApplicationService.Handler.Command
{
    public class DeleteCustomerCommandHandler : IRequestHandler<DeleteCustomerCommand, ResponseBase<bool>>
    {
        private readonly ICustomerRepository _customerRepository;
        public DeleteCustomerCommandHandler(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;

        }
        public async Task<ResponseBase<bool>> Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var entity = await _customerRepository.FindByAsync(c => c.IdentityNumber.Equals(request.IdentityNumber), cancellationToken);
                 _customerRepository.Delete(entity);
                 _customerRepository.SaveChangeAsync(cancellationToken);
                return new ResponseBase<bool>()
                {
                    Status = 1,
                    Message = "Silme işlemi tamamlanmıştır",
                    Result = true
                };
            }
            catch (Exception)
            {
                return new ResponseBase<bool>()
                {
                    Status = 0,
                    Message = "Silme işlemi tamamlanamamıştır",
                    Result = false
                };
            }
        }
    }
}
