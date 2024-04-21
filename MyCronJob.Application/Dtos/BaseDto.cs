namespace MyCronJob.Application.Dtos
{
  public abstract class BaseModel
  {
    public bool IsSuccess { get; set; }
    public string Message { get; set; }
  }
}