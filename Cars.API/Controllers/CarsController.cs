using Cars.Persistence;
using Cars.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Cars.Application;
using MediatR;

namespace Cars.API.Controllers
{
    public class CarsController:BaseApiController
    {
        private readonly IMediator _mediator;

        public CarsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<List<Car>>> GetCars()
        {
            return await _mediator.Send(new List.Query()); 
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Car>> GetCars(Guid id)
        {
            return await _mediator.Send(new Details.Query{ Id=id});
        }

        [HttpPost]
        public async Task<ActionResult> CreateCar(Car car)
        {
            await _mediator.Send(new Create.Command { Car=car });
            return StatusCode(201);
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteCar(Guid id)
        {
            await _mediator.Send(new Delete.Command { Id = id });
            return StatusCode(201);
        }

        [HttpPut]
        public async Task<ActionResult> PutCar( Car car)
        {
            await _mediator.Send(new Edit.Command { Car=car ,Id=car.Id});
            return StatusCode(201);
        }
    }
}
