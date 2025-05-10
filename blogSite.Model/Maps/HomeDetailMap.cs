using blogSite.Core.Map;
using blogSite.Model.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace blogSite.Model.Maps
{
    public class HomeDetailMap: CoreMap<HomeDetail>
    {
        public override void Configure(EntityTypeBuilder<HomeDetail> builder)
        {
            builder.Property(x=> x.Title)
                .HasMaxLength(150)
                .IsRequired();

            builder.Property(x=>x.Details)
                .HasMaxLength(250)
                .IsRequired();
        }
    }
}
