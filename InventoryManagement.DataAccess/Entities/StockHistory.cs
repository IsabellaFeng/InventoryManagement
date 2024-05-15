namespace InventoryManagement.DataAccess.Entities
{
    public class StockHistory
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int IngredientId { get; set; }
        public int StockQuantity { get; set; }
        public Ingredient Ingredient { get; set; } = default!;
    }
}
