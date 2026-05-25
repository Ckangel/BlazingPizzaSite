namespace BlazingPizzaSite
{
    public class OrderWithStatus
    {
        public Order Order { get; set; } = default!;
        public string StatusText { get; set; } = string.Empty;

        public static OrderWithStatus FromOrder(Order order)
        {
            var status = order.Dispatched ? "Dispatched" : "Preparing";
            return new OrderWithStatus
            {
                Order = order,
                StatusText = status
            };
        }
    }
}
