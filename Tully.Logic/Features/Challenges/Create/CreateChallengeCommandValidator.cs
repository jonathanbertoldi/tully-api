using FluentValidation;

namespace Tully.Logic.Features.Challenges.Create
{
  public class CreateChallengeCommandValidator : AbstractValidator<CreateChallengeCommand>
  {
    public CreateChallengeCommandValidator()
    {
      RuleFor(a => a.Name).NotNull().NotEmpty().EmailAddress();
      RuleFor(a => a.Description).NotNull().NotEmpty();
      RuleFor(a => a.PrizeExp).NotNull().NotEmpty();
    }
  }
}
