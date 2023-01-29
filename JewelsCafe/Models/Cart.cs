using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelsCafe.Models
{
    internal class Cart
    {
        public List<IFood> Items { get; set; } = new();
        public decimal Total { get; set; }
    }
}
