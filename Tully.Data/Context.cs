using Microsoft.EntityFrameworkCore;

namespace Tully.Data
{
  public class Context : DbContext
  {
    public Context(DbContextOptions options) : base(options)
    {
    }

    //public DbSet<Challenge> Challenges { get; set; }
  }
}