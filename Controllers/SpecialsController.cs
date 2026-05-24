using Microsoft.AspNetCore.Mvc;

namespace BlazingPizzaSite.Controllers
{
    [ApiController]
    [Route("specials")]
    public class SpecialsController : ControllerBase
    {
        private readonly PizzaStoreContext _context;

        public SpecialsController(PizzaStoreContext context)
        {
            _context = context;
        }

        // GET /specials
        [HttpGet]
        public IEnumerable<Pizza> GetSpecials()
        {
            return _context.Pizzas
                .Include(p => p.Toppings)
                .ToList();
        }
    }
}
