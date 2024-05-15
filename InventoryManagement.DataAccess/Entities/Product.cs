namespace InventoryManagement.DataAccess.Entities
{
    public class Product
    {
        public int ProductId { get; set; }
        public string Name { get; set; } = default!;
        public string Type { get; set; } = default!;
        public ICollection<ProductIngredient>? ProductIngredients { get; set; }
    }
}
