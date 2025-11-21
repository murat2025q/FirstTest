using Microsoft.EntityFrameworkCore;
using Minimarket.Models;

namespace Minimarket.Data
{
    public class MinimarketDbContext : DbContext
    {
        public MinimarketDbContext(DbContextOptions<MinimarketDbContext> options)
            : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
    }
}