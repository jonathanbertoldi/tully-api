using System;
using System.Collections.Generic;
using FluentValidation.Results;
using Tully.Core.Models;

namespace Tully.Logic.Features.Challenges.ViewModels
{
  public class ChallengeView : BaseView
  {
    public ChallengeView()
    {
    }

    public ChallengeView(Challenge challenge)
    {
      Id = challenge.Id;
      Name = challenge.Name;
      Description = challenge.Description;
      Photo = challenge.Photo;
      CreatedAt = challenge.CreatedAt;
      UpdatedAt = challenge.UpdatedAt;
      DeletedAt = challenge.DeletedAt;
    }

    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string Photo { get; set; }
    public int PrizeExp { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public DateTime? DeletedAt { get; set; }
  }
}