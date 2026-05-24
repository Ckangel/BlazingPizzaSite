namespace BlazingPizzaSite
{
    public class Order
    {
        public int OrderId { get; set; }
        public DateTime CreatedTime { get; set; }

        public string CustomerName { get; set; } = string.Empty;
        public string CustomerAddress { get; set; } = string.Empty;

        public List<Pizza> Pizzas { get; set; } = new();

        public bool Dispatched { get; set; }

        public decimal GetTotalPrice()
        {
            return Pizzas.Sum(p => p.GetTotalPrice());
        }
    }
}
