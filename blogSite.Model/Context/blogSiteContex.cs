using blogSite.Model.Entities;
using Microsoft.EntityFrameworkCore;

namespace blogSite.Model.Context
{
    public class BlogSiteContex:DbContext
    {
        public BlogSiteContex(DbContextOptions<BlogSiteContex> options):base(options)
        {

        }

        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            base.ConfigureConventions(configurationBuilder);
        }

        public DbSet<User> Users { get; set; }
    }
}
