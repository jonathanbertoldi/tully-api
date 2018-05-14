using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FluentValidation;
using MediatR;
using Tully.Core.Data;
using Tully.Core.Models;
using Tully.Logic.Exceptions;
using Tully.Logic.Features.Challenges.ViewModels;

namespace Tully.Logic.Features.Challenges.Create
{
  public class Handler : AsyncRequestHandler<CreateChallengeCommand, ChallengeView>
  {
    private IValidator<CreateChallengeCommand> _validator;
    private IChallengeRepository _challengeRepository;
    private IMapper _mapper;

    public Handler(IValidator<CreateChallengeCommand> validator, IChallengeRepository challengeRepository, IMapper mapper)
    {
      _validator = validator;
      _challengeRepository = challengeRepository;
      _mapper = mapper;
    }

    protected override async Task<ChallengeView> HandleCore(CreateChallengeCommand request)
    {
      var validation = _validator.Validate(request);

      if (validation.Errors.Any()) throw new BadRequestException(validation.Errors);

      var challenge = _mapper.Map<Challenge>(request);

      await _challengeRepository.Create(challenge);
      await _challengeRepository.Commit();

      var result = _mapper.Map<ChallengeView>(challenge);

      return result;
    }
  }
}