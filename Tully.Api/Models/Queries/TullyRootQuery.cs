using System.Linq;
using GraphQL.Types;
using Tully.Api.Models.Types;
using Tully.Data.Repositories;

namespace Tully.Api.Models.Queries
{
  public class TullyRootQuery : ObjectGraphType
  {
    public TullyRootQuery(IChallengeRepository challengeRepository)
    {
        Field<ListGraphType<ChallengeType>>(
          "challenges",
          resolve: context => challengeRepository.GetAll().ToList()
        );
    }
  }
}