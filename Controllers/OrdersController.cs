using Microsoft.AspNetCore.Mvc;

namespace BlazingPizzaSite.Controllers
{
    [ApiController]
    [Route("orders")]
    public class OrdersController : ControllerBase
    {
        private readonly PizzaStoreContext _context;

        public OrdersController(PizzaStoreContext context)
        {
            _context = context;
        }

        // GET /orders
        [HttpGet]
        public IEnumerable<OrderWithStatus> GetOrders()
        {
            var orders = _context.Orders
                .Include(o => o.Pizzas)
                    .ThenInclude(p => p.Toppings)
                .OrderByDescending(o => o.CreatedTime)
                .ToList();

            return orders.Select(OrderWithStatus.FromOrder);
        }

        // GET /orders/{orderId}
        [HttpGet("{orderId}")]
        public ActionResult<OrderWithStatus> GetOrder(int orderId)
        {
            var order = _context.Orders
                .Include(o => o.Pizzas)
                    .ThenInclude(p => p.Toppings)
                .SingleOrDefault(o => o.OrderId == orderId);

            if (order == null)
            {
                return NotFound();
            }

            return OrderWithStatus.FromOrder(order);
        }

        // POST /orders
        [HttpPost]
        public ActionResult<Order> PlaceOrder(Order order)
        {
            order.CreatedTime = DateTime.Now;

            _context.Orders.Add(order);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetOrder), new { orderId = order.OrderId }, order);
        }
    }
}
