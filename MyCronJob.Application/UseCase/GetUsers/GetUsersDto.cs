using MyCronJob.Application.Dtos;
using MyCronJob.Domain.Entities;

namespace MyCronJob.Application.UseCase.GetUsers
{
  public class GetUserDto : BaseModel
  {
    public List<User> Data { get; set; }

  }
}