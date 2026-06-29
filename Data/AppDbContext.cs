
using Microsoft.EntityFrameworkCore;

namespace PortfolioCraft.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options) { }
    }

}


