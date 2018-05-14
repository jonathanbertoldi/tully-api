using System;
using System.Collections.Generic;
using System.Linq;
using FluentValidation.Results;
using GraphQL;
using Tully.Logic.Exceptions;

namespace Tully.Api
{
  public static class Extensions
  {
    public static void AddGraphQLExceptionRange(this ExecutionErrors errors, Exception e)
    {
      switch (e) {
        case BadRequestException br:
          errors.AddRange(((List<ValidationFailure>)br.Body).Select(validationFailure => new ExecutionError(validationFailure.ErrorMessage)));
          break;
        default:
          errors.Add(new ExecutionError(e.Message));
          break;
      }
    }
  }
}
