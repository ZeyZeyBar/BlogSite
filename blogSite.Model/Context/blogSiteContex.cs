using blogSite.Model.Entities;
using blogSite.Model.Maps;
using Microsoft.EntityFrameworkCore;

namespace blogSite.Model.Context
{
    public class BlogSiteContex:DbContext
    {
        public BlogSiteContex(DbContextOptions<BlogSiteContex> options):base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserMap());
            modelBuilder.ApplyConfiguration(new AboutMap());
          modelBuilder.ApplyConfiguration(new FormContactMap());    
            modelBuilder.ApplyConfiguration(new HomeDetailMap());
        }

        public DbSet<User> Users { get; set; }
        public DbSet<About> Abouts { get; set; }
        public DbSet<FormContact> FormContacts { get; set; }

        public DbSet<HomeDetail> HomeDetails { get; set; }
    }
}
