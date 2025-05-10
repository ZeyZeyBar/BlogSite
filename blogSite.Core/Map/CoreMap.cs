using blogSite.Core.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace blogSite.Core.Map
{
    public abstract class CoreMap<T> : IEntityTypeConfiguration<T> where T : CoreEntity
    {
        public virtual void Configure(EntityTypeBuilder<T> builder)
        {
            builder.HasKey(x=>x.ID);
            builder.Property(x=>x.CreateTime).IsRequired(false);
            builder.Property(x=>x.UpdateTime).IsRequired(false);
        }
    }
}
