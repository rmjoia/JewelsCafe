﻿namespace JewelsCafe.Models
{
    public interface IFood : IEntity
    {
        
        string Name { get; set; }
        string Description { get; set; }
        IEnumerable<Ingredient> Ingredients { get; set; }
        IEnumerable<string> getAlergens();
        bool IsOptionAvailable { get; set; }
        bool IsSignature { get; set; }
        IEnumerable<string> Options { get; set; }
        BestServeType BestServed { get; set; }
        FoodFamily Family { get; set; }
    }
}