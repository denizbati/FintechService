using FintechService.ApiContract;
using FintechService.ApiContract.Response.Query;
using FintechService.Domain.PFintechServiceAggregate.Repositories.CustomerRepository;
using FintechService.Request.Query;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static MassTransit.ValidationResultExtensions;

namespace FintechService.ApplicationService.Handler.Query
{
    public class GetCustomerQueryHandler : IRequestHandler<GetCustomerQuery, ResponseBase<List<GetCustomerQueryResponse>>>
    {
        private readonly ICustomerRepository _customerRepository;
        public GetCustomerQueryHandler(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }
        public async Task<ResponseBase<List<GetCustomerQueryResponse>>> Handle(GetCustomerQuery request, CancellationToken cancellationToken)
        {
            try
            {
                
                var result = await _customerRepository.GetCustomerWithIdentityNumber(request.IdentityNumber, cancellationToken);
                return new ResponseBase<List<GetCustomerQueryResponse>>()
                {
                    Status = 1,
                    Message = result == null ? "İlgili Data bulunamamıştır": "Success" ,
                    Result = null
                };
                
            }
            catch (Exception)
            {

                return new ResponseBase<List<GetCustomerQueryResponse>>()
                {
                    Status = 0,
                    Message = "DB Connection sıkıntısı var" ,
                    Result = null
                };
            }

          
        }
    }
}
