using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQL;
using GraphQL.Types;
using MediatR;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Tully.Api.Models;
using Tully.Api.Models.Queries;
using Tully.Api.Models.Types;
using Tully.Api.Models.Types.InputTypes;
using Tully.Logic.Features;
using Tully.Core.Data;
using Tully.Data;
using Tully.Data.Repositories;
using FluentValidation;
using Tully.Logic.Features.Challenges.Create;
using System.Reflection;
using Tully.Logic;

namespace Tully.Api
{
  public class Startup
  {
    private IConfiguration Configuration { get; }

    public Startup(IHostingEnvironment env)
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(env.ContentRootPath)
            .AddJsonFile("appSettings.json", optional: false, reloadOnChange: true)
            .AddJsonFile($"appSettings.{env.EnvironmentName}.json", optional: true)
            .AddEnvironmentVariables();

        Configuration = builder.Build();
    }

    // This method gets called by the runtime. Use this method to add services to the container.
    // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
    public void ConfigureServices(IServiceCollection services)
    {
      services
        .AddMvc()
        .AddFluentValidation();

      // Data
      DataInjector.RegisterDataServices(Configuration, services);

      // Logic
      LogicInjector.RegisterLogicServices(Configuration, services);

      // GraphQL
      GraphQLInjector.RegisterGraphQLServices(Configuration, services);
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IHostingEnvironment env)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
      }

      app.UseGraphiQl();
      
      app.UseMvc();
    }
  }
}
