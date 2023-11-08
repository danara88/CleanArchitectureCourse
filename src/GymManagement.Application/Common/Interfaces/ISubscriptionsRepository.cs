using GymManagement.Domain.Subscriptions;

namespace GymManagement.Application.Common.Interfaces
{
    /// <summary>
    /// Subscriptions repository interface
    /// </summary>
    public interface ISubscriptionsRepository
    {
        Task AddSubscriptionAsync(Subscription subscription);

        Task<Subscription> GetByIdAsync(Guid SubscriptionId);
    }
}
