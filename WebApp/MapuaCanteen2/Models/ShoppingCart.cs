using System.Data.Entity;

namespace MapuaCanteen2.Models
{
    public class ShoppingCart
    {
        public int ID { get; set; }
        public string Image { get; set; }
        public string Item { get; set; }
        public decimal PreparationTime { get; set; }
        public decimal Price { get; set; }
        public string Remarks { get; set; }
        public int Quantity { get; set; }
    }

    public class MapuaCanteenDBContext : DbContext
    {
        public DbSet<ShoppingCart> Cart { get; set; }
    }
}