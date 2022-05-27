using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VideoStore.Application.Commands.CreateGenre;
using VideoStore.Application.Queries.GetAllGenre;
using VideoStore.Application.Queries.GetGenreById;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace VideoStore.Controllers
{
    [Route("api/genres")]
    [Authorize]
    public class GenresController : ControllerBase
    {
        private readonly IMediator _mediator;

        public GenresController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Get()
        {
            var getAllGenreQuery = new GetAllGenreQuery();
            var genres = await _mediator.Send(getAllGenreQuery);
            return Ok(genres);
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetById(int id)
        {
            var query = new GetGenreByIdQuery(id);
            var genre = await _mediator.Send(query);
            if (genre == null)
                return NotFound();

            return Ok(genre);
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Post([FromBody] CreateGenreCommand command)
        {
            var id = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetById), new { id = id }, command);
        }
    }
}
