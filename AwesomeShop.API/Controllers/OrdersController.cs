using AwesomeShop.API.Controllers.RequestOrderExamples;
using AwesomeShop.Application.Command;
using AwesomeShop.Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Filters;

namespace AwesomeShop.API.Controllers
{
    [ApiController]
    [Route("/api/custumers/{custumerId}/orders/")]
    public class OrdersController : ControllerBase
    {
        private readonly IMediator _mediator;
        public OrdersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var query = new GetOrderByIdQuery(id);

            var result = await _mediator.Send(query); 

            if(result is null)
                return BadRequest();

            return Ok(result);
        }

        [HttpPost]
        [SwaggerRequestExample(typeof(AddOrderCommand), typeof(AddOrderCommandRequestExample))]
        public async Task<IActionResult> Post([FromBody] AddOrderCommand command)
        {
            var id = await _mediator.Send(command);

            return CreatedAtAction(nameof(Get), new { id = id}, command);
        }
    }
}
