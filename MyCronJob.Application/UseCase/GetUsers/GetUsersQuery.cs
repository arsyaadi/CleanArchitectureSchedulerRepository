using MediatR;

namespace MyCronJob.Application.UseCase.GetUsers
{
  public class GetUserQuery : IRequest<GetUserDto>
  {
    public int Page { get; set; }
    public int Limit { get; set; }
  }
}