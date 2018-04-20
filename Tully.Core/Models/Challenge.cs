using System;

namespace Tully.Core.Models
{
  public class Challenge : IEntity
  {
    public Guid Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public DateTime DeletedAt { get; set; }

    public string Name { get; set; }
    public string Description { get; set; }
    public int PrizeExp { get; set; }
  }
}