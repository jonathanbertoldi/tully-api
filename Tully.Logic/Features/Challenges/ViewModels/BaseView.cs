using System;
using System.Collections.Generic;
using FluentValidation.Results;

namespace Tully.Logic.Features.Challenges.ViewModels
{
  public class BaseView
  {
    public IEnumerable<ValidationFailure> ValidationFailures { get; set; }
  }
}
