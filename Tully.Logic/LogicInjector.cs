using System;
using AutoMapper;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Tully.Logic.Features.Challenges.Create;

namespace Tully.Logic
{
  public class LogicInjector
  {
    public static void RegisterLogicServices(IConfiguration config, IServiceCollection services)
    {
      // MediatR
      services.AddMediatR(typeof(LogicInjector));

      // Validators
      services.AddTransient<IValidator<CreateChallengeCommand>, CreateChallengeCommandValidator>();

      // AutoMapper
      services.AddAutoMapper();
    }
  }
}
