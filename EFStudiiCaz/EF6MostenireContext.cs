using System.Data.Entity;

namespace EFStudiiCaz
{
    public class EF6MostenireContext : DbContext
    {
        public DbSet<Business> Businesses { get; set; }

        //public DbSet<eCommerce> ECommerces { get; set; }

        //public DbSet<Retail> Retails { get; set; }
    }
}