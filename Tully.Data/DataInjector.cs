using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Tully.Core.Data;
using Tully.Data.Repositories;

namespace Tully.Data
{
  public class DataInjector
  {
    public static void RegisterDataServices(IConfiguration config, IServiceCollection services)
    {
      services.AddDbContext<TullyContext>(opt => opt.UseSqlServer(config.GetConnectionString("DefaultConnection")));

      services.AddScoped<IChallengeRepository, ChallengeRepository>();
    }
  }
}
