using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BlazingPizzaSite.Data;

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
        public IEnumerable<Order> GetOrders()
        {
            return _context.Orders
                .Include(o => o.Pizzas)
                .ThenInclude(p => p.Toppings)
                .ToList();
        }

        // POST /orders
        [HttpPost]
        public IActionResult PlaceOrder(Order order)
        {
            order.CreatedTime = DateTime.Now;
            _context.Orders.Add(order);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetOrders), new { id = order.OrderId }, order);
        }
    }
}
