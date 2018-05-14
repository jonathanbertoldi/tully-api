using System;
using AutoMapper;
using Tully.Core.Models;
using Tully.Logic.Features.Challenges.Create;

namespace Tully.Logic.Features.Challenges.ViewModels
{
  public class ChallengeMapperProfile : Profile
  {
    public ChallengeMapperProfile()
    {
      CreateChallengeMappings();
    }

    public void CreateChallengeMappings()
    {
      CreateMap<CreateChallengeCommand, Challenge>();

      CreateMap<Challenge, ChallengeView>();
    }
  }
}
