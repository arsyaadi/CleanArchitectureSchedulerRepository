
using MediatR;
using MyCronJob.Application.UseCase.GetUsers;
using MyCronJob.Worker.Dto;
using MyCronJob.Worker.Services.Interfaces;

namespace MyCronJob.Worker.Services
{

  public class UserService : IUserService
  {
    private readonly IMediator _mediator;

    public UserService(IMediator mediator)
    {
      _mediator = mediator;
    }

    public async Task<UserListDto> GetUserListAsync()
    {
      try
      {
        var query = new GetUserQuery()
        {
          Page = 1,
          Limit = 10,
        };

        var getUserDto = await _mediator.Send(query);

        var userListDto = new UserListDto();

        if (getUserDto != null && getUserDto.Data != null)
        {
          userListDto = new UserListDto
          {
            Data = getUserDto.Data.Select(x => new UserDto
            {
              Id = x.Id,
              Name = x.Name,
              CreatedAt = x.CreatedAt,
            }).ToList(),
            IsSuccess = getUserDto.IsSuccess,
            Message = getUserDto.Message,
          };
        }
        else
        {
          userListDto = new UserListDto
          {
            Data = null,
            IsSuccess = false,
            Message = "Failed to retrieve user list",
          };
        }

        return userListDto;
      }
      catch (Exception ex)
      {
        throw new Exception(ex.Message);
      }
    }
  }

}