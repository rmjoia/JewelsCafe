using System;
namespace JewelsCafe.Models
{
    public class Beverege
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public BeveregeType Type { get; set; }

        public bool IsSignature { get; set; }

        public IEnumerable<Ingredient> Ingredients { get; set; }

        public IEnumerable<string> getAlergens()
        {
            return Ingredients.Where(i => i.IsAlergen).Select(i => i.Name);
        }

        public bool IsOptionAvailable { get; set; }

        public IEnumerable<string> Options { get; set; }
    }
}
