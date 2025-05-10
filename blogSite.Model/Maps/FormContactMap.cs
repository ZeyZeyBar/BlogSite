using blogSite.Core.Map;
using blogSite.Model.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace blogSite.Model.Maps
{
    public class FormContactMap: CoreMap<FormContact>
    {
        public override void Configure(EntityTypeBuilder<FormContact> builder)
        {
            builder.Property(x => x.NameSurname)
                .HasMaxLength(150)
                .IsRequired();

            builder.Property(x=>x.Email)
                .HasMaxLength(150)
                .IsRequired();

            builder.Property(x=>x.PhoneNumber)
                .HasMaxLength(100)
                .IsRequired(false);

            builder.Property(x=>x.Message)
                .HasMaxLength(250)
                .IsRequired();
        }
    }
}
