using GraphQL.Types;
using Tully.Api.Models.Types;
using Tully.Api.Models.Types.InputTypes;
using Tully.Core.Models;
using Tully.Data.Repositories;

namespace Tully.Api.Models.Queries
{
  public class TullyMutation : ObjectGraphType
  {
    public TullyMutation(IChallengeRepository challengeRepository)
    {
      Name = "TullyMutation";

      FieldAsync<ChallengeType>(
        "createChallenge",
        arguments: new QueryArguments(
          new QueryArgument<NonNullGraphType<ChallengeInputType>> { Name = "challenge" }
        ),
        resolve: async (context) =>
        {
          var challenge = context.GetArgument<Challenge>("challenge");

          await challengeRepository.Create(challenge);
          await challengeRepository.Commit();

          return challenge;
        }
      );
    }
  }
}