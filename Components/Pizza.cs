using System;
using System.Collections.Generic;

namespace BlazingPizzaSite
{
    public class Pizza
    {
        public int PizzaId { get; set; }
        public string Size { get; set; } = "Medium";
        public List<Topping> Toppings { get; set; } = new List<Topping>();

        // Base price depending on size
        public decimal GetBasePrice()
        {
            return Size switch
            {
                "Small" => 8.00m,
                "Medium" => 10.00m,
                "Large" => 12.00m,
                _ => 10.00m
            };
        }

        // Total price = base price + toppings
        public decimal GetTotalPrice()
        {
            decimal total = GetBasePrice();
            foreach (var topping in Toppings)
            {
                total += topping.Price;
            }
            return total;
        }
    }

    public class Topping
    {
        public int ToppingId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
    }
}
