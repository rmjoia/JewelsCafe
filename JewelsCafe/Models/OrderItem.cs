using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelsCafe.Models
{
    public class OrderItem
    {
        public IFood Food { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }
}
