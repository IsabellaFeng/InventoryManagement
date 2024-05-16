using InventoryManagement.DataAccess.Data;
using InventoryManagement.DataAccess.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Application.Scenarios.GetIngredient
{

    public sealed class GetIngredientsHandler : IRequestHandler<GetIngredientsRequest, List<Ingredient>>
    {
        private readonly IDbContextFactory<InventoryDbContext> _dbContext;

        public GetIngredientsHandler(IDbContextFactory<InventoryDbContext> dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Ingredient>> Handle(GetIngredientsRequest request, CancellationToken cancellationToken)
        {
            var dbContext = await _dbContext.CreateDbContextAsync(cancellationToken);
            return await dbContext.Ingredients.ToListAsync(cancellationToken);
        }
    }
}
