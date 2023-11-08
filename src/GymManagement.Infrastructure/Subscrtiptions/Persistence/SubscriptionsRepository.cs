using GymManagement.Application.Common.Interfaces;
using GymManagement.Domain.Subscriptions;
using GymManagement.Infrastructure.Common.Persistence;

namespace GymManagement.Infrastructure.Subscriptions.Persistence;

/// <summary>
/// Subscription repository implementation
/// </summary>
public class SubscriptionsRepository : ISubscriptionsRepository
{
  private readonly GymManagementDbContext _context;

  public SubscriptionsRepository(GymManagementDbContext context)
  {
    _context = context;
  }

  /// <summary>
  /// Method to store a subscription in DB
  /// </summary>
  /// <param name="subscription"></param>
  /// <returns></returns>
  public async Task AddSubscriptionAsync(Subscription subscription)
  {
    await _context.Subscriptions.AddAsync(subscription);
    await _context.SaveChangesAsync();
  }

  /// <summary>
  /// Method to get a subscription from DB
  /// </summary>
  /// <param name="SubscriptionId"></param>
  /// <returns></returns>
  public async Task<Subscription> GetByIdAsync(Guid SubscriptionId)
  {
    return await _context.Subscriptions.FindAsync(SubscriptionId);
  }
}
