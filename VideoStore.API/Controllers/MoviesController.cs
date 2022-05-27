using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Threading.Tasks;
using VideoStore.Application.Commands.CreateMovie;
using VideoStore.Application.Commands.VoteMovie;
using VideoStore.Application.Queries.GetAllMovie;
using VideoStore.Application.Queries.GetMovieById;
using VideoStore.Core.Pagination;

namespace VideoStore.Controllers
{
    [Route("api/movies")]
    [Authorize]
    public class MoviesController : ControllerBase
    {

        private readonly IMediator _mediator;

        public MoviesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Get(MovieParameters parameters)
        {
            var getAllMovieQuery = new GetAllMovieQuery(parameters);

            var movies = await _mediator.Send(getAllMovieQuery);
            var metaData = new { movies.CurrentPage, movies.PageSize, movies.TotalPages, movies.TotalRecords, movies.HasNext, movies.HasPrevious };
            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(metaData));
            return Ok(new { movies, metaData });
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetById(int id)
        {
            var query = new GetMovieByIdQuery(id);
            var movie = await _mediator.Send(query);
            if (movie == null)
                return NotFound();

            return Ok(movie);
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Post([FromBody] CreateMovieCommand command)
        {
            var id = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetById), new { id = id }, command);
        }

        [HttpPost("vote")]
        [AllowAnonymous]
        public async Task<IActionResult> Vote([FromBody] VoteMovieCommand command)
        {
            var movieVoted = await _mediator.Send(command);

            return Ok(movieVoted);
        }
    }
}
