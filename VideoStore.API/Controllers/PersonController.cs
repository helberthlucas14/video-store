using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VideoStore.Application.Commands;
using VideoStore.Application.Queries.GetPeopleById;
using VideoStore.Application.Queries.GetAllPersonQuery;
using Microsoft.AspNetCore.Authorization;

namespace VideoStore.Controllers
{
    [Route("api/persons")]
    public class PersonController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PersonController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Get()
        {
            var GetAllPersonQuery = new GetAllPersonQuery();
            var people = await _mediator.Send(GetAllPersonQuery);
            return Ok(people);
        }

        [HttpGet("people/{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetById(int id)
        {
            var query = new GetPeopleByIdQuery(id);
            var productionCompany = await _mediator.Send(query);
            if (productionCompany == null)
                return NotFound();

            return Ok(productionCompany);
        }

        [HttpPost("people")]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Post([FromBody] CreatePeopleCommand command)
        {
            var id = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetById), new { id = id }, command);
        }
    }
}
