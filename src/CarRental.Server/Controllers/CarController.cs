using CarRental.Application.UseCases.Car.Create;
using CarRental.Application.UseCases.Car.Get;
using CarRental.Core.Model;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CarRental.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CarController : ControllerBase
    {
        private readonly ILogger<CarController> _logger;
        private IMediator _mediator;
        public CarController(IMediator mediator, ILogger<CarController> logger)
        {
            _logger = logger;
            _mediator = mediator;
        }
        [HttpGet(Name = "GetCar")]
        public async Task<IEnumerable<Car<int>>> Get()
        {
            var request = new GetAllCarQuery<int>();
            var response = await _mediator.Send(request);
            return response;
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] Car<int> car)
        {
            var command = new CreateCarCommand<int> { NewCar = car };
            var result = await _mediator.Send(command);
            return Ok(result);

        }
    }
}