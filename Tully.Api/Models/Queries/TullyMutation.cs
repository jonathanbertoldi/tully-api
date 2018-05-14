using System;
using System.Collections.Generic;
using System.Linq;
using FluentValidation;
using FluentValidation.Results;
using GraphQL;
using GraphQL.Types;
using GraphQL.Validation;
using MediatR;
using Tully.Api.Models.Types;
using Tully.Api.Models.Types.InputTypes;
using Tully.Core.Data;
using Tully.Core.Models;
using Tully.Data.Repositories;
using Tully.Logic.Exceptions;
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

          try
          {
            var result = await mediator.Send(challengeCommand);

            return result;
          }
          catch (Exception e)
          {
            context.Errors.AddGraphQLExceptionRange(e);

            return null;
          }
        }
      );
    }
  }
}