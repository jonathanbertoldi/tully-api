using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using MediatR;
using Tully.Core.Data;
using Tully.Core.Models;
using Tully.Logic.Features.Challenges.ViewModels;

namespace Tully.Logic.Features.Challenges.Create
{
  public class Handler : AsyncRequestHandler<CreateChallengeCommand, ChallengeView>
  {
    private readonly IValidator<CreateChallengeCommand> _validator;
    private readonly IChallengeRepository _challengeRepository;

    public Handler(IValidator<CreateChallengeCommand> validator, IChallengeRepository challengeRepository)
    {
      _validator = validator;
      _challengeRepository = challengeRepository;
    }

    protected override async Task<ChallengeView> HandleCore(CreateChallengeCommand command)
    {
      var result = _validator.Validate(command);

      if (result.Errors.Any()) return new ChallengeView { ValidationFailures = result.Errors };

      var challenge = new Challenge
      {
        Name = command.Name,
        Description = command.Description,
        PrizeExp = command.PrizeExp
      };

      await _challengeRepository.Create(challenge);
      await _challengeRepository.Commit();

      return new ChallengeView(challenge);
    }
  }
}