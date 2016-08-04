using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MapuaCanteen2.Models.Stores
{
    public class Paotsin
    {
        public int ID { get; set; }
        public string Image { get; set; }
        public string Item { get; set; }
        public decimal PreparationTime { get; set; }
        public decimal Price { get; set; }
        public string Remarks { get; set; }
        public int Stock { get; set; }
    }

    public class MapuaCanteenDBContext : DbContext
    {
        public DbSet<Paotsin> Products { get; set; }
    }
}