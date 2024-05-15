using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;


namespace InventoryManagement.Application.Scenarios.CreateIngredient
{
    public sealed class CreateIngredientRequest : IRequest<int>
    {
        public int IngredientId { get; set; }
        public string Name { get; set; } = default!;

        public string Unit { get; set; } = default!;

        public int Quantity { get; set; }

        public decimal UnitPrice { get; set; }
        public DateTime LastUpdatedAt { get; set; }
    }
}
