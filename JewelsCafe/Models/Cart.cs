using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelsCafe.Models
{
    internal class Cart
    {
        public List<CartItem> Items { get; set; }
        public decimal VatTotal { get; set; }
        public decimal Total { get; set; }
    }
}
