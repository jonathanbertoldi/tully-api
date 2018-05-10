using System;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Tully.Logic.Features.Challenges.Create;

namespace Tully.Logic
{
  public class LogicUtils
  {
    public static void RegisterLogicServices(IConfiguration config, IServiceCollection services)
    {
      // MediatR
      services.AddMediatR(typeof(LogicUtils));

      // Validators
      services.AddTransient<IValidator<CreateChallengeCommand>, CreateChallengeCommandValidator>();
    }
  }
}
