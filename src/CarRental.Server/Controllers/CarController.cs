using CarRental.Application.UseCases.Car;
using CarRental.Application.UseCases.Car.Commands.Create;
using CarRental.Application.UseCases.Car.Queries.Get;
using CarRental.Application.UseCases.Dto;
using CarRental.Core.Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CarRental.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CarController : ControllerBase
    {
        private readonly ILogger<CarController> _logger;
        private IMediator _mediator;
        public CarController(IMediator mediator, ILogger<CarController> logger)
        {
            _logger = logger;
            _mediator = mediator;
        }

        //add imemorycache to method Get

        [HttpGet(Name = "GetCar")]
        public async Task<IEnumerable<CarDto>> Get()
        {
            var request = new GetAllCarQuery();
            var response = await _mediator.Send(request);

            return response;
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] CarDto car)
        {
            var command = new CreateCarCommand(car);
            var result = await _mediator.Send(command);
            return Ok(result);

        }
    }
}