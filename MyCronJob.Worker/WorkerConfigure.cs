using Quartz;
using MyCronJob.Worker.Jobs;
using MyCronJob.Worker.Services.Interfaces;
using MyCronJob.Worker.Services;

namespace MyCronJob.Worker
{
  public static class AppWorkerExtension
  {
    public static void AppWorker(this IServiceCollection services, IConfiguration configuration)
    {
      // configure worker service
      ConfigureWorkerService(services);

      ConfigureQuartzJob<UserJob>(services, "UserJob", "UserJobTrigger", "0/30 0/1 * 1/1 * ? *");

      services.AddQuartzHostedService(option =>
      {
        option.WaitForJobsToComplete = true;
      });

    }

    private static void ConfigureQuartzJob<TJob>(IServiceCollection services, string jobIdentity, string triggerIdentity, string cronExpression) where TJob : IJob
    {
      services.AddQuartz(q =>
      {
        q.AddJob<TJob>(opts => opts.WithIdentity(jobIdentity));
        q.AddTrigger(opt => opt
          .ForJob(jobIdentity)
          .WithIdentity(triggerIdentity)
          .WithCronSchedule(cronExpression));
      });
    }

    private static void ConfigureWorkerService(IServiceCollection services)
    {
      services.AddTransient<IUserService, UserService>();
    }

  }
}