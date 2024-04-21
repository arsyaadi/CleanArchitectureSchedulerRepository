using MediatR;
using MyCronJob.Domain.Entities;
using MyCronJob.Domain.Interfaces;

namespace MyCronJob.Application.UseCase.GetUsers
{
  public class GetUserHandle : IRequestHandler<GetUserQuery, GetUserDto>
  {

    private readonly IRepository<User> _userRepository;

    public GetUserHandle(IRepository<User> userRepository)
    {
      _userRepository = userRepository;
    }

    public async Task<GetUserDto> Handle(GetUserQuery request, CancellationToken cancellationToken)
    {
      var dto = new GetUserDto
      {
        Message = "Success",
        IsSuccess = true,
      };

      var result = await _userRepository.GetAll(request.Page, request.Limit, cancellationToken);

      if (result.Any())
      {
        dto.Data = result.Select(x => new User
        {
          Id = x.Id,
          Name = x.Name,
          CreatedAt = x.CreatedAt,
        }).ToList();
      }

      return dto;
    }
  }
}