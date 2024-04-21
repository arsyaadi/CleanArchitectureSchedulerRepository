using MyCronJob.Worker.Services.Dto;

namespace MyCronJob.Worker.Dto
{
  public class UserListDto : BaseDto
  {
    public List<UserDto> Data { get; set; }
  }
}