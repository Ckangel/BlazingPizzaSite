using Microsoft.EntityFrameworkCore;

namespace BlazingPizzaSite
{
    public class PizzaStoreContext : DbContext
    {
        public PizzaStoreContext(DbContextOptions<PizzaStoreContext> options)
            : base(options)
        {
        }

        public DbSet<Order> Orders { get; set; }
        public DbSet<Pizza> Pizzas { get; set; }
        public DbSet<Topping> Toppings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure relationships
            modelBuilder.Entity<Order>()
                .HasMany(o => o.Pizzas)
                .WithOne()
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Pizza>()
                .HasMany(p => p.Toppings)
                .WithOne()
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
