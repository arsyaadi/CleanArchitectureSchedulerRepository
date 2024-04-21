using Microsoft.Extensions.DependencyInjection;
using MyCronJob.Domain.Entities;
using MyCronJob.Domain.Interfaces;
using MyCronJob.Infrastructure.Persistence.Repositories;

namespace MyCronJob.Infrastructure
{
  public static class RepositoryConfiguration
  {
    public static IServiceCollection AddRepository(this IServiceCollection services)
    {
      services.AddScoped<IRepository<User>, Repository>();
      return services;
    }
  }
}
