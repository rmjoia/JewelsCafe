using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelsCafe.Models
{
    public class Checkout
    {
        public Guid Id { get; set; }
        public Order Order { get; set; }
        public DateTime Date { get; set; }
    }
}
