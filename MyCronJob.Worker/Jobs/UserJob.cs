using MyCronJob.Worker.Services.Interfaces;
using Quartz;

namespace MyCronJob.Worker.Jobs
{
  public class UserJob : IJob
  {
    private ILogger<UserJob> _logger;
    private readonly IUserService _userService;

    public UserJob(ILogger<UserJob> logger, IUserService userService)
    {
      _logger = logger;
      _userService = userService;
    }

    public async Task Execute(IJobExecutionContext context)
    {
      try
      {
        var userDto = await _userService.GetUserListAsync();

        var firstUser = userDto?.Data?.FirstOrDefault();

        if (firstUser != null)
        {
          _logger.LogInformation($"First User Name: {firstUser.Name} Id: {firstUser.Id}");
        }
        else
        {
          _logger.LogInformation("Not users found");
        }
        string currentDateTimeString = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        _logger.LogInformation($"Console Job running at {currentDateTimeString}");
      }
      catch (Exception ex)
      {
        _logger.LogInformation($"Error: {ex.Message}");
      }
    }
  }
}