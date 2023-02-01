using JewelsCafe.Models;
using JewelsCafe.Repositories;

namespace JewelsCafe;

public partial class App : Application
{
    private readonly GenericRepository<Beverage> _beveragesRepository;
    private readonly GenericRepository<Food> _foodsRepository;

    public App(GenericRepository<Beverage> beveragesRepository, GenericRepository<Food> foodsRepository)
    {
        InitializeComponent();

        MainPage = new AppShell();

        _beveragesRepository = beveragesRepository;
        _foodsRepository = foodsRepository;

        SeedData();
    }

    private void SeedData()
    {
        var juices = new List<IFood>
        {
            new Beverage {
                Id =  Guid.NewGuid(),
                Name = "Coca Cola",
                Description = "Tastes Funny",
                Ingredients = new List<Ingredient> {
                    new Ingredient { Id = Guid.NewGuid(), Name = "Sugar", IsAlergen = true },
                    new Ingredient { Id = Guid.NewGuid(), Name = "Caramel", IsAlergen = false },
                    new Ingredient { Id = Guid.NewGuid(), Name = "Secret mixture", IsAlergen = false }
                },
                IsOptionAvailable= true,
                IsSignature = false,
                Options = new List<string>{"Diet","Zero","Cherry","No Caffeine"},
                BestServed = BestServeType.Cold,
                Family = FoodFamily.Soda,
                Price = 2.50M,
                Picture = "coca_cola_icon.png"
            },
            new Beverage {
                Id =  Guid.NewGuid(),
                Name = "Fanta",
                Description = "Sparkling Fruit Juice",
                Ingredients = new List<Ingredient> {
                    new Ingredient { Id = Guid.NewGuid(), Name = "Sugar", IsAlergen = true },
                    new Ingredient { Id = Guid.NewGuid(), Name = "Fruit Fuice", IsAlergen = false },
                },
                IsOptionAvailable= true,
                IsSignature = false,
                Options = new List<string>{"Orange","Lemon","Pinapple"},
                BestServed = BestServeType.Cold,
                Family = FoodFamily.Soda,
                Price = 2.50M,
                Picture = "fanta_icon.png"
            },
            new Beverage {
                Id =  Guid.NewGuid(),
                Name = "Orange Squeeze",
                Description = "Natural Fruit Juice",
                Ingredients = new List<Ingredient> {
                    new Ingredient { Id = Guid.NewGuid(), Name = "Fruit Fuice", IsAlergen = false },
                },
                IsOptionAvailable= true,
                IsSignature = false,
                Options = new List<string>{"Orange","Lemon","Pinapple"},
                BestServed = BestServeType.Cold,
                Family = FoodFamily.Juice,
                Price = 2.50M,
                Picture = "orange_squeeze_icon.png"
            }
        };

        var coffees = new List<IFood>
        {
            new Beverage {
                Id = new Guid("f1b5b1f0-5f9f-4b9f-9c1c-1b1b1b1b1b1b"),
                Name = "Jewel's Roast Coffee",
                Description = "Dark custom blend of arabian selected coffee and a mixture of spices",
                Ingredients = new List<Ingredient> {
                        new Ingredient { Id = Guid.NewGuid(), Name = "Coffee", IsAlergen = false },
                        new Ingredient { Id = Guid.NewGuid(), Name = "mixture of oriental spices", IsAlergen = false },
                    },
                IsOptionAvailable = true,
                IsSignature = false,
                Options = new List<string> { "Milk", "Almond Milk", "Oat Milk", "Coconut Milk" },
                BestServed = BestServeType.Hot,
                Family = FoodFamily.Coffee,
                Price = 2.50M,
                Picture = "coffee.png"
            },
            new Beverage {
                Id = Guid.NewGuid(),
                Name = "Jewel's Cappuccino",
                Description = "A cappuccino is an espresso-based coffee drink that originated in Italy and is traditionally prepared with steamed milk foam",
                Ingredients = new List<Ingredient> {
                        new Ingredient { Id = Guid.NewGuid(), Name = "Coffee", IsAlergen = false },
                        new Ingredient { Id = Guid.NewGuid(), Name = "Milk", IsAlergen = true },
                        new Ingredient { Id = Guid.NewGuid(), Name = "cinnamon", IsAlergen = false },
                        new Ingredient { Id = Guid.NewGuid(), Name = "chocolate", IsAlergen = false },
                        new Ingredient { Id = Guid.NewGuid(), Name = "mixture of special secret spices", IsAlergen = false },
                    },
                IsOptionAvailable = true,
                IsSignature = false,
                Options = new List<string> { "Milk", "Almond Milk", "Oat Milk", "Coconut Milk" },
                BestServed = BestServeType.Hot,
                Family = FoodFamily.Coffee,
                Price = 5.00M,
                Picture = "cappuccino_icon.png"
            },
            new Beverage {
                Id = Guid.NewGuid(),
                Name = "Jewel's Latte",
                Description = "Caffè latte, often shortened to just latte in English, is a coffee beverage of Italian origin made with espresso and steamed milk.",
                Ingredients = new List<Ingredient> {
                        new Ingredient { Id = Guid.NewGuid(), Name = "Coffee", IsAlergen = false },
                        new Ingredient { Id = Guid.NewGuid(), Name = "Milk", IsAlergen = true },
                        new Ingredient { Id = Guid.NewGuid(), Name = "mixture of special secret spices", IsAlergen = false },
                    },
                IsOptionAvailable = true,
                IsSignature = false,
                Options = new List<string> { "Milk", "Almond Milk", "Oat Milk", "Coconut Milk" },
                BestServed = BestServeType.Hot,
                Family = FoodFamily.Coffee,
                Price = 5.00M,
                Picture = "latte_icon.png"
            },
        };

        var teas = new List<IFood>
        {
            new Beverage {
                Id = Guid.NewGuid(),
                Name = "Green Tea",
                Description = "Green tea is a type of tea that is made from Camellia sinensis leaves and buds that have not undergone the same withering and oxidation process which is used to make oolong teas and black teas.",
                Ingredients = new List<Ingredient> {
                        new Ingredient { Id = Guid.NewGuid(), Name = "Green Tea", IsAlergen = false },
                    },
                IsOptionAvailable = true,
                IsSignature = false,
                Options = new List<string> { },
                BestServed = BestServeType.Hot,
                Family = FoodFamily.Tea,
                Price = 2.0M,
                Picture = "green_tea_icon.png"
            },
            new Beverage {
                Id = Guid.NewGuid(),
                Name = "Chamomile Tea",
                Description = "Chamomile tea is made from the chamomile flower and is used to treat a wide range of health issues.",
                Ingredients = new List<Ingredient> {
                        new Ingredient { Id = Guid.NewGuid(), Name = "Chamomile Tea", IsAlergen = false },
                    },
                IsOptionAvailable = true,
                IsSignature = false,
                Options = new List<string> { },
                BestServed = BestServeType.Hot,
                Family = FoodFamily.Tea,
                Price = 2.0M,
                Picture = "chamomile_tea_icon.png"
            },
            new Beverage {
                Id = Guid.NewGuid(),
                Name = "Black Tea",
                Description = "Black tea, also translated to red tea in various East Asian languages, is a type of tea that is more oxidized than oolong, yellow, white and green teas.",
                Ingredients = new List<Ingredient> {
                        new Ingredient { Id = Guid.NewGuid(), Name = "Black Tea", IsAlergen = false },
                    },
                IsOptionAvailable = true,
                IsSignature = false,
                Options = new List<string> { "Milk", "Almond Milk", "Oat Milk", "Coconut Milk" },
                BestServed = BestServeType.Hot,
                Family = FoodFamily.Tea,
                Price = 2.0M,
                Picture = "black_tea_icon.png"
            },
        };

        var chocolates = new List<IFood>
        {
            new Food {
                Id = Guid.NewGuid(),
                Name = "M&Ms",
                Description = "Lovely with a cup of tea",
                Ingredients = new List<Ingredient> {
                        new Ingredient { Id = Guid.NewGuid(), Name = "Milk Chocolate", IsAlergen = false },
                    },
                IsOptionAvailable = true,
                IsSignature = false,
                Options = new List<string> { "Peanut", "Salt", "Peanut Butter" },
                BestServed = BestServeType.Cold,
                Family = FoodFamily.Chocolate,
                Price = 2.0M,
                Picture = "m_and_ms_icon.png"
            },
            new Food {
                Id = Guid.NewGuid(),
                Name = "Lion Bar",
                Description = "A poor man's Toffee Crisp",
                Ingredients = new List<Ingredient> {
                        new Ingredient { Id = Guid.NewGuid(), Name = "Milk Chocolate", IsAlergen = false },
                        new Ingredient { Id = Guid.NewGuid(), Name = "Toffee", IsAlergen = false },
                    },
                IsOptionAvailable = true,
                IsSignature = false,
                Options = new List<string> { },
                BestServed = BestServeType.Cold,
                Family = FoodFamily.Chocolate,
                Price = 2.0M,
                Picture = "lion_icon.png"
            },
            new Food {
                Id = Guid.NewGuid(),
                Name = "Twix",
                Description = "You want a Twix right now, don't you?",
                Ingredients = new List<Ingredient> {
                        new Ingredient { Id = Guid.NewGuid(), Name = "Milk Chocolate", IsAlergen = false },
                        new Ingredient { Id = Guid.NewGuid(), Name = "Carmel", IsAlergen = false },
                        new Ingredient { Id = Guid.NewGuid(), Name = "Butter Biscuit", IsAlergen = false },
                    },
                IsOptionAvailable = true,
                IsSignature = false,
                Options = new List<string> { },
                BestServed = BestServeType.Cold,
                Family = FoodFamily.Chocolate,
                Price = 2.0M,
                Picture = "twix_icon.png"
            },
            new Food {
                Id = Guid.NewGuid(),
                Name = "Mars",
                Description = "It came THIS close to taking the top spot, beaten only by another classic...",
                Ingredients = new List<Ingredient> {
                        new Ingredient { Id = Guid.NewGuid(), Name = "Milk Chocolate", IsAlergen = false },
                        new Ingredient { Id = Guid.NewGuid(), Name = "Carmel", IsAlergen = false },
                    },
                IsOptionAvailable = true,
                IsSignature = false,
                Options = new List<string> { },
                BestServed = BestServeType.Cold,
                Family = FoodFamily.Chocolate,
                Price = 2.0M,
                Picture = "mars_icon.png"
            },
        };

        _beveragesRepository.Add(coffees);
        _beveragesRepository.Add(teas);
        _beveragesRepository.Add(juices);
        _foodsRepository.Add(chocolates);
    }
}

