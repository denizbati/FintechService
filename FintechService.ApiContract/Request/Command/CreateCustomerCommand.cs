using FintechService.ApiContract;
using FintechService.Response.Command;
using MediatR;

namespace FintechService.Request.Command
{
    public class CreateCustomerCommand :IRequest<ResponseBase<CreateCustomerCommandResponse>>
    {
    }
}
