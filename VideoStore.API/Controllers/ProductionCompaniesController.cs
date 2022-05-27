using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VideoStore.Application.Commands;
using VideoStore.Application.Queries.GetAllProductionCompany;
using VideoStore.Application.Queries.GetProductionCompanyById;

namespace VideoStore.Controllers
{
    [Route("api/production_companies")]
    public class ProductionCompaniesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductionCompaniesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Get()
        {
            var getAllProdcutionCompanyQuery = new GetAllProductionCompanyQuery();
            var productionCompany = await _mediator.Send(getAllProdcutionCompanyQuery);
            return Ok(productionCompany);
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetById(int id)
        {
            var query = new GetProductionCompanyByIdQuery(id);
            var productionCompany = await _mediator.Send(query);
            if (productionCompany == null)
                return NotFound();

            return Ok(productionCompany);
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Post([FromBody] CreateProductionCompanyCommand command)
        {
            var id = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetById), new { id = id }, command);
        }
    }
}
