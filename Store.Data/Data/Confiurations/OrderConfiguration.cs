

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Store.Data.Entities.Order;

namespace Store.Data.Data.Confiurations
{
    public class OrderConfiguration : IEntityTypeConfiguration<Orders>
    {
        public void Configure(EntityTypeBuilder<Orders> builder)
        {
            builder.OwnsOne(X => X.ShippingAddress, X =>
            {
                X.WithOwner();

            }
            );
                builder.HasMany(X=>X.OrderItems).WithOne()
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
