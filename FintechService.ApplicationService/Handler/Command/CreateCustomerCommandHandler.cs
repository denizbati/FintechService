using FintechService.ApiContract;
using FintechService.Domain.PFintechServiceAggregate;
using FintechService.Domain.PFintechServiceAggregate.Repositories.CustomerRepository;
using FintechService.Request.Command;
using FintechService.Response.Command;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FintechService.ApplicationService.Handler.Command
{
    public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, ResponseBase<bool>>
    {
        private readonly ICustomerRepository _customerRepository;
        public CreateCustomerCommandHandler(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;

        }

        public async Task<ResponseBase<bool>> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {

            // distributedlock çok iyi olurdu ama zamanım kalmadı maalesef 
            try
            {
                var createCustomer = new Customer()
                {
                    CreatedDate = DateTime.Now,
                    IdentityNumber = request.IdentityNumber,
                    IsActive = true,
                    Name = request.Name,
                    Surname = request.Surname
                };
               await _customerRepository.CreateCustomer(createCustomer, cancellationToken);
               await _customerRepository.SaveChangeAsync(cancellationToken);



                // bununiçin de bir base class yazılabilir.
                return new ResponseBase<bool>()
                {
                    Status = 1,
                    Message = "müşteri oluşturma işlemi tamamlanmıştır",
                    Result = true
                };
            }
            catch (Exception)
            {

                return new ResponseBase<bool>()
                {
                    Status = 0,
                    Message = "müşteri oluşturma işlemi tamamlanamamıştır",
                    Result = false
                }; 
            }
        }
    }
}
