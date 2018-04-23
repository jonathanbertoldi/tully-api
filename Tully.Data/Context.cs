using Microsoft.EntityFrameworkCore;
using Tully.Core.Models;
using Tully.Data.Configurations;

namespace Tully.Data
{
  public class Context : DbContext
  {
    public Context(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Challenge> Challenges { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
      base.OnModelCreating(builder);

      builder.ApplyConfiguration(new ChallengeConfig());
    }
  }
}