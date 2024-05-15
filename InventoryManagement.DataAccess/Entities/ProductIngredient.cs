namespace InventoryManagement.DataAccess.Entities
{
    public class ProductIngredient
    {
        public int ProductId { get; set; }
        public Product Product { get; set; } = default!;

        public int IngredientId { get; set; }
        public Ingredient Ingredient { get; set; } = default!;
    }
}
