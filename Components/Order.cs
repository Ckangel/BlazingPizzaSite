using System;
using System.Collections.Generic;

namespace BlazingPizzaSite
{
    public class Order
    {
        public int OrderId { get; set; }
        public DateTime CreatedTime { get; set; }
        public List<Pizza> Pizzas { get; set; } = new List<Pizza>();

        // Flags for workflow status
        public bool Dispatched { get; set; }
        public bool Delivered { get; set; }

        // Customer info
        public string CustomerName { get; set; }
        public string CustomerAddress { get; set; }

        public string Name { get; set; } = string.Empty;
        public string CustomerName { get; set; } = string.Empty;
        public string CustomerAddress { get; set; } = string.Empty;
        public Order Order { get; set; } = new Order();
        public string StatusText { get; set; } = string.Empty;


        // Total price calculation
        public decimal GetTotalPrice()
        {
            decimal total = 0;
            foreach (var pizza in Pizzas)
            {
                total += pizza.GetTotalPrice();
            }
            return total;
        }
    }
}
