

using Microsoft.Extensions.DependencyInjection;
using MyCronJob.Application.UseCase.GetUsers;

namespace MyCronJob.Application
{
  public static class ApplicationConfigure
  {
    public static IServiceCollection AddApplicationConfig(this IServiceCollection services)
    {
      services.AddMediatR(x => x.RegisterServicesFromAssemblies(typeof(GetUserQuery).Assembly));
      return services;
    }
  }

}