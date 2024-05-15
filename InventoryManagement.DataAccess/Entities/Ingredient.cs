namespace InventoryManagement.DataAccess.Entities
{
    public class Ingredient
    {
        public int IngredientId { get; set; }
        public string Name { get; set; } = default!;

        public string Unit { get; set; } = default!;

        public int Quantity { get; set; }

        public decimal UnitPrice { get; set; }
        public DateTime LastUpdatedAt { get; set; }
    }
}
