using Cars.Domain;
using Microsoft.EntityFrameworkCore;

namespace Cars.Persistence
{
    public class DataContext:DbContext
    {
        public DataContext(DbContextOptions options) : base(options) { }
        public DbSet<Car> Cars { get; set; }
    }
}