using Microsoft.EntityFrameworkCore;

namespace IT_ATCB_Consumable_Inventory_System.Models
{
    public class InventoryContext : DbContext
    {
        public InventoryContext(DbContextOptions<InventoryContext> options) : base(options) { }

        public DbSet<Item> Items { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Item>().ToTable("ITEMS");
            modelBuilder.Entity<Category>().ToTable("CATEGORIES");
            modelBuilder.Entity<Supplier>().ToTable("SUPPLIERS");
        }
    }
}