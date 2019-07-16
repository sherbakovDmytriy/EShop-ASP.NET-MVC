using DAL.Models;
using System.Data.Entity;

namespace DAL.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext() : base("EShopConnectionString")
        {
            //Database.SetInitializer(new DbInitializer());
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Size> Sizes { get; set; }
        public DbSet<TradeMark> TradeMarks { get; set; }

        public DbSet<Type> Types { get; set; }
        public DbSet<Subtype> Subtypes { get; set; }
    }
}