namespace InventoryManagement.DataAccess.Entities
{
    public class Sale
    {
        public int SaleId { get; set; }
        public DateTime Date { get; set; }
        public decimal Total { get; set; }

        public ICollection<SaleItem> SaleItems { get; set; } = default!;
    }
}
