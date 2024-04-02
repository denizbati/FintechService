using FintechService.ApiContract;
using FintechService.ApiContract.Response.Query;
using MediatR;
using System.Collections.Generic;

namespace FintechService.Request.Query
{
    public class GetCustomerQuery: IRequest<ResponseBase<List<GetCustomerQueryResponse>>>
    {
        public long IdentityNumber { get; set; }
    }
}
