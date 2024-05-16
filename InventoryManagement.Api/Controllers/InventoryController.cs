using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using InventoryManagement.DataAccess.Data;
using InventoryManagement.DataAccess.Entities;
using MediatR;
using InventoryManagement.Application.Scenarios.CreateIngredient;
using InventoryManagement.Application.Scenarios.GetIngredient;

namespace InventoryManagement.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [EnableCors("OpenCorsPolicy")]
    public class InventoryController : ControllerBase
    {
        private readonly IDbContextFactory<InventoryDbContext> _dbContextFactory;
        private readonly IMediator _mediator;

        public InventoryController(IDbContextFactory<InventoryDbContext> dbContextFactory, IMediator mediator)
        {
            _dbContextFactory = dbContextFactory;
            _mediator = mediator;
        }

        [HttpPut("Ingredients")]
        public async Task<IActionResult> AddIngredient([FromBody] CreateIngredientRequest request)
        {
            var id = await _mediator.Send(request);

            return Ok(id);
        }

        [HttpGet("Ingredients")]
        public async Task<IActionResult> GetIngredients()
        {
            var ingredients = await _mediator.Send(new GetIngredientsRequest());
            return Ok(ingredients);
        }

        [HttpPost("CreateDB")]
        public async Task<IActionResult> CreateDB()
        {
            var dbContext = await _dbContextFactory.CreateDbContextAsync();
            await dbContext.Database.EnsureCreatedAsync();
            return Ok();
        }

    }
}
