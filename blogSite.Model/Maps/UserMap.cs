using blogSite.Core.Map;
using blogSite.Model.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace blogSite.Model.Maps
{
    public class UserMap:CoreMap<User>
    {
        public override void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(x => x.Name)
                .HasMaxLength(250)
                .IsRequired();

            builder.Property(x=>x.Surname)
                .HasMaxLength(250)
                .IsRequired();

            builder.Property(x => x.UserName)
                .HasMaxLength(150)
                .IsRequired();

            builder.Property(x=>x.Password)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(x => x.IsActive)
                .IsRequired();
        }
    }
}
