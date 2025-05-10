using blogSite.Model.Entities;
using Microsoft.EntityFrameworkCore;

namespace blogSite.Model.Context
{
    public class blogSiteContex:DbContext
    {
        public blogSiteContex(DbContextOptions dbContextOptions):base(dbContextOptions) { }

        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            base.ConfigureConventions(configurationBuilder);
        }

        public DbSet<User> Users { get; set; }
    }
}
