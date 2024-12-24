using Infrastructure.Entities;

namespace Infrastructure.Persistence
{
    public class DatabaseContextInitializer
    {
        private readonly DatabaseContext _context;

        public DatabaseContextInitializer(DatabaseContext context)
        {
            _context = context;
        }

        public void Initialise()
        {
            Seed();
        }

        private void Seed()
        {
            if (!_context.Categories.Any())
            {
                var categories = new List<CategoryEntity>
                {
                    new CategoryEntity { Name = "Corporate" },
                    new CategoryEntity { Name = "Drive-Thru" },
                    new CategoryEntity { Name = "Hipster" },
                    new CategoryEntity { Name = "Modern" },
                    new CategoryEntity { Name = "Urban" },
                    new CategoryEntity { Name = "Upscale" }
                };

                _context.Categories.AddRange(categories);
                var categoryDict = categories.ToDictionary(c => c.Name);


                var coffees = new List<CoffeeEntity>
                {
                    new CoffeeEntity { Name = "Black", Description = "Classic dark roast coffee from organic arabica beans", Price = 2.99m, ImageSource = "black_coffee.png"},
                    new CoffeeEntity { Name = "Latte", Description = "Original Italian latte made with espresso and steamed milk", Price = 3.99m, ImageSource = "latte_coffee.png"},
                    new CoffeeEntity { Name = "Espresso", Description = "Silky, finely ground beans brewed under high pressure", Price = 3.99m, ImageSource = "espresso_coffee.png"},
                    new CoffeeEntity { Name = "Americano", Description = "Espresso with added hot water for a lighter taste", Price = 2.99m, ImageSource = "americano_coffee.png"},
                    new CoffeeEntity { Name = "Cappuccino", Description = "Streamed and foamed cream or milk with espresso shots", Price = 3.99m, ImageSource = "cappuccino_coffee.png"},
                };

                _context.Coffees.AddRange(coffees);   
                var coffeeDict = coffees.ToDictionary(c => c.Name);

                var shops = new List<ShopEntity>
                {
                    new ShopEntity
                    {
                        Name = "Ovation",
                        Rating = 4.5,
                        ImageSource = "shop_photo1.png",
                        Categories = new List<CategoryEntity>
                        {
                            categoryDict["Modern"],
                            categoryDict["Corporate"],
                            categoryDict["Urban"],
                            categoryDict["Upscale"]
                        },
                        Coffees = new List<CoffeeEntity>
                        {
                            coffeeDict["Black"],
                            coffeeDict["Latte"],
                            coffeeDict["Espresso"],
                            coffeeDict["Americano"],
                            coffeeDict["Cappuccino"]
                        }
                    },
                    new ShopEntity
                    {
                        Name = "Cafe 5to2",
                        Rating = 4.7,
                        ImageSource = "shop_photo2.png",
                        Categories = new List<CategoryEntity>
                        {
                            categoryDict["Urban"],
                            categoryDict["Upscale"],
                            categoryDict["Drive-Thru"]
                        },
                        Coffees = new List<CoffeeEntity>
                        {
                            coffeeDict["Black"],
                            coffeeDict["Latte"],
                            coffeeDict["Espresso"],
                            coffeeDict["Americano"],
                            coffeeDict["Cappuccino"]
                        }
                    },
                    new ShopEntity
                    {
                        Name = "Murray Hill’s",
                        Rating = 3.9,
                        ImageSource = "shop_photo3.png",
                        Categories = new List<CategoryEntity>
                        {
                            categoryDict["Urban"],
                            categoryDict["Corporate"],
                            categoryDict["Drive-Thru"],
                            categoryDict["Hipster"]
                        },
                        Coffees = new List<CoffeeEntity>
                        {
                            coffeeDict["Black"],
                            coffeeDict["Latte"],
                            coffeeDict["Espresso"],
                            coffeeDict["Americano"],
                            coffeeDict["Cappuccino"]
                        }
                    }
                };

                _context.Shops.AddRange(shops);
                _context.SaveChanges();
            }
        }
    }
}
