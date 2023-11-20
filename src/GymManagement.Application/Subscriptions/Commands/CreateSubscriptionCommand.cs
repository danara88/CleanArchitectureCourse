using ErrorOr;
using GymManagement.Domain.Subscriptions;
using MediatR;

namespace GymManagement.Application.Subscriptions.Commands
{
    /// <summary>
    /// Create subscription command
    /// </summary>
    /// <param name="AdminId"></param>
    /// <param name="SubscriptionType"></param>
    public record CreateSubscriptionCommand(Guid adminId, SubscriptionType subscriptionType): IRequest<ErrorOr<Subscription>>;
}
