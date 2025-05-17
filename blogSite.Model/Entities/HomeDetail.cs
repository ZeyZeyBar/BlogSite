using blogSite.Core.Entity;

namespace blogSite.Model.Entities
{
    public class HomeDetail : CoreEntity
    {
        public string Title { get; set; }
        public string Details { get; set; }
        public byte[]? Image { get; set; }
        public bool IsActive { get; set; }
    }
}
