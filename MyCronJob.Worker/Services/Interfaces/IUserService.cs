using System.Threading.Tasks;
using MyCronJob.Worker.Dto;

namespace MyCronJob.Worker.Services.Interfaces
{
  public interface IUserService
  {
    Task<UserListDto> GetUserListAsync();
  }
}