﻿namespace GymManagement.Domain.Subscriptions
{
    /// <summary>
    /// Subscription entity
    /// </summary>
    public class Subscription
    {
        private readonly Guid _adminId;
        public Guid Id { get; private set; }
        public SubscriptionType SubscriptionType { get; private set; }

        public Subscription(Guid adminId, SubscriptionType subscriptionType, Guid? id = null)
        {
            Id = id ?? Guid.NewGuid();
            _adminId = adminId;
            SubscriptionType = subscriptionType;
        }

        private Subscription()
        {

        }
    }
}
