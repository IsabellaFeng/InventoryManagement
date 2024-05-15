namespace InventoryManagement.DataAccess.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public string Email { get; set; } = default!;
        public string Password { get; set; } = default!;
        public DateTime LastLogin { get; set; }
        public string UserType { get; set; } = default!;
    }
}
