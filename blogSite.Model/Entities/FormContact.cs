using blogSite.Core.Entity;

namespace blogSite.Model.Entities
{
    public class FormContact: CoreEntity
    {
        public string NameSurname {  get; set; }
        public string Email { get; set; }
        public string? PhoneNumber { get; set; }

        public string Message {  get; set; }
    }
}
