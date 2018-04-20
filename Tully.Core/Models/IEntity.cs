using System;

namespace Tully.Core.Models
{
  public interface IEntity
  {
    Guid Id { get; set; }
    DateTime CreatedAt { get; set; }
    DateTime UpdatedAt { get; set; }
    DateTime DeletedAt { get; set; }
  }
}