using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelsCafe.Models
{
    public class Food : IFood
    {
        public Guid Id { get; set; }

        public string Name { get; set; }
        
        public BestServeType BestServed { get; set; }

        public FoodFamily Family { get; set; }

        public string Description { get; set; }

        public bool IsSignature { get; set; }

        public IEnumerable<Ingredient> Ingredients { get; set; }

        public IEnumerable<string> getAlergens()
        {
            return Ingredients.Where(i => i.IsAlergen).Select(i => i.Name);
        }

        public bool IsOptionAvailable { get; set; }

        public IEnumerable<string> Options { get; set; }

        public decimal Price { get; set; }

        public decimal Discount { get; set; }

        public decimal Vat { get; set; }
    }
}
