using blogSite.Core.Entity;

namespace blogSite.Model.Entities
{
    public class About : CoreEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsActive {  get; set; }
    }
}
