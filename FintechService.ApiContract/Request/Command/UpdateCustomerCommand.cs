using FintechService.ApiContract;
using FintechService.Response.Command;
using MediatR;

namespace FintechService.Request.Command
{
    public class UpdateCustomerCommand:IRequest<ResponseBase<bool>>
    {
        public long IdentityNumber { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
    }
}
