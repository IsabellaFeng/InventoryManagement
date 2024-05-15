using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventoryManagement.DataAccess.Data;
using InventoryManagement.DataAccess.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;


namespace InventoryManagement.Application.Scenarios.CreateIngredient
{
    public sealed class CreateIngredientHandler : IRequestHandler<CreateIngredientRequest, int>
    {
        private readonly IDbContextFactory<InventoryDbContext> _dbContext;
        public CreateIngredientHandler(IDbContextFactory<InventoryDbContext> dbcontext)
        {
            _dbContext = dbcontext;
        }
        public async Task<int> Handle(CreateIngredientRequest request, CancellationToken cancellationToken)
        {
            var ingredient = new Ingredient
            {
                Name = request.Name,
                Unit = request.Unit,
                Quantity = request.Quantity,
                UnitPrice = request.UnitPrice,
                LastUpdatedAt = DateTime.UtcNow
            };

            var dbContext = await _dbContext.CreateDbContextAsync();
            dbContext.Ingredients.Add(ingredient);
            await dbContext.SaveChangesAsync(cancellationToken);

            return ingredient.IngredientId;
        }
    }
}
