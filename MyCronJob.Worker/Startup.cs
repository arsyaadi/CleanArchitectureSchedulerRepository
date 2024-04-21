using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MyCronJob.Infrastructure.SqlServer;
using MyCronJob.Worker;
using Microsoft.EntityFrameworkCore;
using MyCronJob.Infrastructure;
using MediatR;
using MyCronJob.Application;

namespace MyCronJob.Worker
{
  public class Startup
  {
    public Startup(IConfiguration configuration)
    {
      Configuration = configuration;
    }
    public IConfiguration Configuration { get; }

    public void ConfigureServices(IServiceCollection services)
    {
      // Add Connection String
      services.AddDbContext<SqlServerDbContext>();

      // Add Worker
      services.AppWorker(Configuration);

      services.AddRepository();
      services.AddApplicationConfig();
    }


    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {

    }

  }
}
