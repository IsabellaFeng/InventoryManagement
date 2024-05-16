using InventoryManagement.DataAccess.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Application.Scenarios.GetIngredient
{
    public sealed class GetIngredientsRequest : IRequest<List<Ingredient>>
    {
    }
}
