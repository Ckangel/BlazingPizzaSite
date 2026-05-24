using Microsoft.EntityFrameworkCore;

namespace BlazingPizzaSite.Data
{
    public class PizzaStoreContext : DbContext
    {
        public PizzaStoreContext(DbContextOptions<PizzaStoreContext> options)
            : base(options)
        {
        }

        public DbSet<Order> Orders { get; set; } = default!;
        public DbSet<Pizza> Pizzas { get; set; } = default!;
        public DbSet<Topping> Toppings { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
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
