using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MapuaCanteen.Models
{
    public class PaotsinProducts
    {
        public int ID { get; set; }
        public string Image { get; set; }
        public string Item { get; set; }
        public decimal PreparationTime { get; set; }
        public decimal Price { get; set; }
        public string Remarks { get; set; }
        public int Stock { get; set; }
    }
}
