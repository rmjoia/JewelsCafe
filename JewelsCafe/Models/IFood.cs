namespace JewelsCafe.Models
{
    public interface IFood
    {
        string Description { get; set; }
        Guid Id { get; set; }
        IEnumerable<Ingredient> Ingredients { get; set; }
        bool IsOptionAvailable { get; set; }
        bool IsSignature { get; set; }
        string Name { get; set; }
        IEnumerable<string> Options { get; set; }
        BestServeType Type { get; set; }

        IEnumerable<string> getAlergens();
    }
}