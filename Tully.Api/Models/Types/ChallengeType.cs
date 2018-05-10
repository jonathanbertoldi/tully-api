using GraphQL.Types;
using Tully.Core.Models;
using Tully.Logic.Features.Challenges.ViewModels;

namespace Tully.Api.Models.Types
{
  public class ChallengeType : ObjectGraphType<ChallengeView>
  {
    public ChallengeType()
    {
      Field(a => a.Id, type: typeof(IdGraphType));
      Field(a => a.Name);
      Field(a => a.Photo);
      Field(a => a.PrizeExp);
      Field(a => a.Description);
      Field(a => a.CreatedAt, type: typeof(DateGraphType));
      Field(a => a.UpdatedAt, type: typeof(DateGraphType));
      Field(a => a.DeletedAt, type: typeof(DateGraphType));
    }
  }
}