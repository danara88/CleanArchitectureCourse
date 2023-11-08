namespace GymManagement.Domain.Subscriptions
{
    /// <summary>
    /// Subscription entity
    /// </summary>
    public class Subscription
    {
        public Guid Id { get; set; }

        public string? SubscriptionType { get; set; }
    }
}
