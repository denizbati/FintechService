using FintechService.ApiContract;
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
    public class UpdateCustomerCommandHandler : IRequestHandler<UpdateCustomerCommand, ResponseBase<bool>>
    {
       
        private readonly ICustomerRepository _customerRepository;
        public UpdateCustomerCommandHandler( ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;

        }

        public  async Task<ResponseBase<bool>>  Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var entity = await _customerRepository.FindByAsync(c => c.IdentityNumber.Equals(request.IdentityNumber), cancellationToken);

                if (request.Name!=null)
                {
                    entity.Name = request.Name;
                }
                if (request.Surname != null)
                {
                    entity.Surname = request.Surname;
                }
              

                _customerRepository.Update(entity);
                _customerRepository.SaveChangeAsync(cancellationToken);
                return new ResponseBase<bool>()
                {
                    Status = 1,
                    Message = "Güncelleme işlemi tamamlanmıştır",
                    Result = true
                };
            }
            catch (Exception)
            {
                return new ResponseBase<bool>()
                {
                    Status = 0,
                    Message = "Güncelleme işlemi tamamlanamamıştır",
                    Result = false
                };
            }
        }
    }
}
