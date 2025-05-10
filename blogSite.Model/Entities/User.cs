using blogSite.Core.Entity;

namespace blogSite.Model.Entities
{
    public class User:CoreEntity
    {
        public string Name { get; set; }
        public string Surname {  get; set; }
        public string UserName {  get; set; }
        public string Password {  get; set; }
    }
}
