using FluentValidation;
using MediatR;
using Tully.Logic.Features.Challenge.ViewModels;

namespace Tully.Logic.Features.Challenge
{
  public class Create
  {
    public class Command : IRequest<ChallengeView>
    {
      public string Name { get; set; }
      public string Description { get; set; }
      public int PrizeExp { get; set; }
    }

    public class CommandValidator : AbstractValidator<Command>
    {
      public CommandValidator()
      {
        RuleFor(a => a.Name).NotNull().NotEmpty();
        RuleFor(a => a.Description).NotNull().NotEmpty();
        RuleFor(a => a.PrizeExp).NotNull().NotEmpty();
      }
    }
  }
}