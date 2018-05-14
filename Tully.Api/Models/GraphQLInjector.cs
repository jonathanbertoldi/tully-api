using System;
using GraphQL;
using GraphQL.Types;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Tully.Api.Models.Queries;
using Tully.Api.Models.Types;
using Tully.Api.Models.Types.InputTypes;

namespace Tully.Api.Models
{
  public class GraphQLInjector
  {
    public static void RegisterGraphQLServices(IConfiguration config, IServiceCollection services)
    {
      services.AddSingleton<IDocumentExecuter, DocumentExecuter>();

      services.AddSingleton<TullyRootQuery>();
      services.AddSingleton<TullyMutation>();

      services.AddSingleton<ChallengeType>();
      services.AddSingleton<ChallengeInputType>();

      var sp = services.BuildServiceProvider();
      services.AddSingleton<ISchema>(new TullySchema(new FuncDependencyResolver(type => sp.GetService(type))));
    }
  }
}
