namespace BlazingPizzaSite
{
    public class OrderState
    {
        public Order Order { get; private set; } = new();

        public void ResetOrder()
        {
            Order = new Order();
        }
    }
}
