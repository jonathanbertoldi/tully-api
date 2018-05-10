using MediatR;
using Tully.Logic.Features.Challenges.ViewModels;

namespace Tully.Logic.Features.Challenges.Create
{
  public class CreateChallengeCommand : IRequest<ChallengeView>
  {
    public string Name { get; set; }
    public string Description { get; set; }
    public int PrizeExp { get; set; }
  }
}