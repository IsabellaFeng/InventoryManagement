using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using InventoryManagement.DataAccess.Data;
using InventoryManagement.DataAccess.Entities;

namespace InventoryManagement.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [EnableCors("OpenCorsPolicy")]
    public class InventoryController : ControllerBase
    {
        private readonly IDbContextFactory<InventoryDbContext> _dbContextFactory;

        public InventoryController(IDbContextFactory<InventoryDbContext> dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }

        [HttpPut("Ingredients")]
        public async Task<IActionResult> AddIngredient([FromBody] Ingredient ingredient)
        {
            var dbContext = await _dbContextFactory.CreateDbContextAsync();
            dbContext.Ingredients.Add(ingredient);
            await dbContext.SaveChangesAsync();

            return Ok(ingredient.IngredientId);
        }

        [HttpGet("Ingredients")]
        public async Task<IActionResult> GetIngredients()
        {
            var dbContext = await _dbContextFactory.CreateDbContextAsync();
            var ingredients = await dbContext.Ingredients.ToListAsync();
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
