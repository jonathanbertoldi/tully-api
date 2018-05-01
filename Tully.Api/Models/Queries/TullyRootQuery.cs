using System.Linq;
using GraphQL.Types;
using Microsoft.EntityFrameworkCore;
using Tully.Api.Models.Types;
using Tully.Data.Repositories;

namespace Tully.Api.Models.Queries
{
  public class TullyRootQuery : ObjectGraphType
  {
    public TullyRootQuery(IChallengeRepository challengeRepository)
    {
        FieldAsync<ListGraphType<ChallengeType>>(
          "challenges",
          resolve: async (context) => await challengeRepository.GetAll().ToListAsync()
        );
    }
  }
}