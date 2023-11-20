using ErrorOr;
using GymManagement.Application.Common.Interfaces;
using GymManagement.Domain.Subscriptions;
using MediatR;

namespace GymManagement.Application.Subscriptions.Commands
{
    /// <summary>
    /// Create subscription command handler
    /// </summary>
    public class CreateSubscriptionCommandHandler : IRequestHandler<CreateSubscriptionCommand, ErrorOr<Subscription>>
    {
        private readonly ISubscriptionsRepository _subscriptionsRepository;
        private readonly IUnitOfOWork _unitOfWork;

        public CreateSubscriptionCommandHandler(ISubscriptionsRepository subscriptionsRepository, IUnitOfOWork unitOfWork)
        {
            _subscriptionsRepository = subscriptionsRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<ErrorOr<Subscription>> Handle(CreateSubscriptionCommand request, CancellationToken cancellationToken)
        {
            // Create a subscription
            var subscription = new Subscription(
                subscriptionType: request.subscriptionType,
                adminId: request.adminId
            );

            // Add it to the database
            await _subscriptionsRepository.AddSubscriptionAsync(subscription);
            await _unitOfWork.CommitChangedAsync();

            // Return subscription
            return subscription;
        }
    }
}
