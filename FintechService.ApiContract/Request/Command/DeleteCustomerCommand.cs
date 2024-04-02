using FintechService.ApiContract;
using FintechService.Response.Command;
using MediatR;

namespace FintechService.Request.Command
{
    public class DeleteCustomerCommand:IRequest<ResponseBase<bool>>
    {
        public string IdentityNumber { get; set; }
    }
}
