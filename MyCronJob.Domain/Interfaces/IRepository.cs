
namespace MyCronJob.Domain.Interfaces
{
  public interface IRepository<TEntity> where TEntity : class
  {
    Task<List<TEntity>> GetAll(int pageNumber, int pageSize, CancellationToken cancellationToken);
  }
}