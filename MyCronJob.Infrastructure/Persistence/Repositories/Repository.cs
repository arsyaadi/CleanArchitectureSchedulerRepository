
using Microsoft.EntityFrameworkCore;
using MyCronJob.Domain.Entities;
using MyCronJob.Domain.Interfaces;
using MyCronJob.Infrastructure.SqlServer;

namespace MyCronJob.Infrastructure.Persistence.Repositories
{
  public class Repository : IRepository<User>
  {

    private readonly SqlServerDbContext _sqlServerDbContext;

    public Repository(SqlServerDbContext sqlServerDbContext)
    {
      _sqlServerDbContext = sqlServerDbContext;
    }

    public async Task<List<User>> GetAll(int pageNumber, int pageSize, CancellationToken cancellationToken)
    {
      int recordToSkip = (pageNumber - 1) * pageSize;
      var query = _sqlServerDbContext.User.AsQueryable();

      int totalCount = await query.CountAsync();

      if (totalCount == 0)
      {
        var notFound = await query.ToListAsync(cancellationToken);
        return notFound.ToList();
      }

      int totalPages = (int)Math.Ceiling((double)totalCount / pageSize);
      pageNumber = Math.Clamp(pageNumber, 1, totalPages);

      var response = await query
        .Skip(recordToSkip)
        .Take(pageSize)
        .ToListAsync(cancellationToken);

      return response;
    }
  }

}