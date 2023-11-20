using GymManagement.Domain.Subscriptions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GymManagement.Infrastructure.Common.Persistence
{
    public class SubscriptionConfiguration : IEntityTypeConfiguration<Subscription>
    {
        public void Configure(EntityTypeBuilder<Subscription> builder)
        {
            builder.HasKey(prop => prop.Id);

            // We are generating by using GUID in the app
            builder.Property(prop => prop.Id)
                .ValueGeneratedNever();

            // Configuring the private property to assign column
            builder.Property("_adminId")
                .HasColumnName("AdminId");

            // Will store in database the enum value (0, 1, 2) etc
            builder.Property(prop => prop.SubscriptionType)
                .HasConversion(
                    subscriptionType => subscriptionType.Value,
                    value => SubscriptionType.FromValue(value)
                );

            // Will store in databse the name enum (Free, Pro) etc
            // This will be more readable
            //builder.Property(prop => prop.SubscriptionType)
            //    .HasConversion(
            //        subscriptionType => subscriptionType.Name,
            //        value => SubscriptionType.FromName(value, false)
            //    );
        }
    }
}
