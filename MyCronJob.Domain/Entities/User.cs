
namespace MyCronJob.Domain.Entities
{
  public class User
  {
    public Guid Id { get; set; }
    public string Name { get; set; }
    public DateTime CreatedAt { get; set; }
  }
}