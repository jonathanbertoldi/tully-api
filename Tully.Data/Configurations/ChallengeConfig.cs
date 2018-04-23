using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tully.Core.Models;

namespace Tully.Data.Configurations
{
  public class ChallengeConfig : IEntityTypeConfiguration<Challenge>
  {
    public void Configure(EntityTypeBuilder<Challenge> b)
    { 
      b.ToTable("Challenge");

      b.HasKey(c => c.Id);

      b.Property(c => c.Photo)
        .IsRequired()
        .HasDefaultValue("challenges/default-challenge-photo.jpg");

      b.Property(c => c.CreatedAt)
        .IsRequired()
        .HasDefaultValueSql("GETDATE()");
    }
  }
}