using System;

namespace BlazingPizzaSite
{
    public class OrderWithStatus
    {
        public Order Order { get; set; }
        public string StatusText { get; set; }

        public string Name { get; set; } = string.Empty;
        public string CustomerName { get; set; } = string.Empty;
        public string CustomerAddress { get; set; } = string.Empty;
        public Order Order { get; set; } = new Order();
        public string StatusText { get; set; } = string.Empty;

        public bool IsDelivered => StatusText == "Delivered";

        public static OrderWithStatus FromOrder(Order order)
        {
            // Example logic: you can adjust based on your app’s workflow
            string statusText;
            if (order.Delivered)
            {
                statusText = "Delivered";
            }
            else if (order.Dispatched)
            {
                statusText = "Out for delivery";
            }
            else
            {
                statusText = "Preparing";
            }

            return new OrderWithStatus
            {
                Order = order,
                StatusText = statusText
            };
        }
    }
}
