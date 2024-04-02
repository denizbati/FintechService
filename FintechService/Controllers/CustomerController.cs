using FintechService.ApiContract;
using FintechService.ApiContract.Response.Query;
using FintechService.Request.Command;
using FintechService.Request.Query;
using FintechService.Response.Command;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FintechService.Controllers
{
    [Route("customer")]
    [Produces("application/json")]
    [ApiController]
    public class CustomerController:ControllerBase
    {

        private readonly IMediator _mediator;

        public CustomerController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet()]
        [ProducesResponseType(200, Type = typeof(ResponseBase<List<GetCustomerQueryResponse>>))]
        public async Task<IActionResult> GetCustomer([FromQuery] GetCustomerQuery request)
        {
            var result = await _mediator.Send(request);
            return Ok(result);
        }
        [HttpPost("create")]
        [ProducesResponseType(200, Type = typeof(ResponseBase<bool>))]
        public async Task<IActionResult> Create([FromBody] CreateCustomerCommand request)
        {
            var result = await _mediator.Send(request);
            return Ok(result);
        }
        [HttpPut("update")]
        [ProducesResponseType(200, Type = typeof(ResponseBase<bool>))]
        public async Task<IActionResult> UpdateCustomer([FromBody] UpdateCustomerCommand request)
        {
            var result = await _mediator.Send(request);
            return Ok(result);
        }

        [HttpDelete("delete")]
        [ProducesResponseType(200, Type = typeof(ResponseBase<bool>))]
        public async Task<IActionResult> DeleteCustomer (DeleteCustomerCommand request)
        {
            var result = await _mediator.Send(request);
            return Ok(result);
        }
    }
}
