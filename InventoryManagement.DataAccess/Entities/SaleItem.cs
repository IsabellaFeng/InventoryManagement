namespace InventoryManagement.DataAccess.Entities
{
    public class SaleItem
    {
        public int SaleItemId { get; set; }
        public int SaleId { get; set; }
        public int ProductId { get; set; }

        public Sale Sale { get; set; } = default!;
        public Product Product { get; set; } = default!;
    }
}
