using System;
using System.Linq;
using FluentValidation;
using GraphQL;
using GraphQL.Types;
using MediatR;
using Tully.Api.Models.Types;
using Tully.Api.Models.Types.InputTypes;
using Tully.Core.Data;
using Tully.Core.Models;
using Tully.Data.Repositories;
using Tully.Logic.Features.Challenges.Create;

namespace Tully.Api.Models.Queries
{
  public class TullyMutation : ObjectGraphType
  {
    public TullyMutation(IMediator mediator)
    {
      Name = "TullyMutation";

      FieldAsync<ChallengeType>(
        "createChallenge",
        arguments: new QueryArguments(
          new QueryArgument<NonNullGraphType<ChallengeInputType>> { Name = "challenge" }
        ),
        resolve: async (context) =>
        {
          var challengeCommand = context.GetArgument<CreateChallengeCommand>("challenge");

          var result = await mediator.Send(challengeCommand);

          return result;
        }
      );
    }
  }
}