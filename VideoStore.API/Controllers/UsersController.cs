using DevFreela.Application.Commands.LoginUser;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VideoStore.Application.Commands.ChangePassword;
using VideoStore.Application.Commands.CreateUser;
using VideoStore.Application.Commands.SoftDeleteUser;
using VideoStore.Application.Queries.GetAllUsers;
using VideoStore.Application.Queries.GetUserById;
using VideoStore.Core.Pagination;

namespace VideoStore.Controllers
{
    [Route("api/users")]
    [Authorize]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet, Authorize(Roles = "admin")]
        public async Task<IActionResult> Get(UserParameters parameters)
        {
            var getAllUsersQuery = new GetAllUsersQuery(parameters);

            var users = await _mediator.Send(getAllUsersQuery);
            var metaData = new { users.CurrentPage, users.PageSize, users.TotalPages, users.TotalRecords };
            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(metaData));
            return Ok(new { users, metaData });
        }

        [HttpGet("{id}"), Authorize(Roles = "admin")]
        public async Task<IActionResult> GetById(int id)
        {
            var query = new GetUserByIdQuery(id);
            var user = await _mediator.Send(query);
            if (user == null)
                return NotFound();

            return Ok(user);
        }

        [HttpPost, AllowAnonymous]
        public async Task<IActionResult> Post([FromBody] CreateUserCommand command)
        {
            var id = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetById), new { id = id });
        }

        [HttpPut, AllowAnonymous]
        public async Task<IActionResult> Put([FromBody] ChangePasswordCommand command)
        {
            await _mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id}"), Authorize(Roles = "admin")]
        public async Task<IActionResult> Delete(int id)
        {
            await _mediator.Send(new SoftDeleteUserCommand(id));
            return NoContent();
        }

        [HttpPut("login"), AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] LoginUserCommand command)
        {
            var loginUserViewModel = await _mediator.Send(command);

            if (loginUserViewModel == null)
                return BadRequest();

            return Ok(loginUserViewModel);
        }
    }
}
