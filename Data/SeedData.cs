namespace BlazingPizzaSite.Data
{
    public static class SeedData
    {
        public static void Initialize(PizzaStoreContext context)
        {
            context.Database.EnsureCreated();

            if (context.Pizzas.Any())
            {
                return;
            }

            var specials = new List<Pizza>
            {
                new Pizza
                {
                    Size = "Large",
                    Toppings = new List<Topping>
                    {
                        new Topping { Name = "Cheese", Price = 2.00m },
                        new Topping { Name = "Pepperoni", Price = 3.00m },
                        new Topping { Name = "Mushrooms", Price = 1.50m }
                    }
                },
                new Pizza
                {
                    Size = "Medium",
                    Toppings = new List<Topping>
                    {
                        new Topping { Name = "Cheese", Price = 2.00m },
                        new Topping { Name = "Ham", Price = 3.00m },
                        new Topping { Name = "Pineapple", Price = 2.50m }
                    }
                }
            };

            context.Pizzas.AddRange(specials);
            context.SaveChanges();
        }
    }
}
