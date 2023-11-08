using GymManagement.Application;
using GymManagement.Domain.Subscriptions;
using Microsoft.EntityFrameworkCore;

namespace GymManagement.Infrastructure.Common.Persistence;

/// <summary>
/// Gym management context
/// </summary>
public class GymManagementDbContext : DbContext, IUnitOfOWork
{
  public GymManagementDbContext(DbContextOptions options) : base(options) { }

  public DbSet<Subscription> Subscriptions { get; set; }

  /// <summary>
  /// Commit changes
  /// </summary>
  /// <returns></returns>
  public async Task CommitChangedAsync()
  {
    await base.SaveChangesAsync();
  }
}
