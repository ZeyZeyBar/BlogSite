using blogSite.Core.Map;
using blogSite.Model.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace blogSite.Model.Maps
{
    public class AboutMap :CoreMap<About>
    {
        public override void Configure(EntityTypeBuilder<About> builder)
        {
            builder.Property(x => x.Title)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(x => x.Description)
                .HasMaxLength(250)
                .IsRequired();

            builder.Property(x=>x.IsActive)
                .IsRequired();
        }
    }
}
