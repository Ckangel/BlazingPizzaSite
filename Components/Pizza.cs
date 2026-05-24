namespace BlazingPizzaSite
{
    public class Pizza
    {
        public int PizzaId { get; set; }
        public string Size { get; set; } = "Medium";

        public List<Topping> Toppings { get; set; } = new();

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

        public decimal GetTotalPrice()
        {
            return GetBasePrice() + Toppings.Sum(t => t.Price);
        }
    }
}
