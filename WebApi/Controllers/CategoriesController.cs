using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Commands;
using Application.Queries;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CategoriesController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpGet]
        public async Task<ActionResult<List<Category>>> List()
        {
            return await _mediator.Send(new ListCategory.Query());
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Category>> Details(int id)
        {
            return await _mediator.Send(new DetailsCategory.Query { Id = id });
        }


        [HttpPost]
        public async Task<ActionResult<Unit>> Create(CreateCategory.Command command)
        {
            return await _mediator.Send(command);
        }
    }
}
