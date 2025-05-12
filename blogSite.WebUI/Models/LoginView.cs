namespace blogSite.WebUI.Models
{
    public class LoginView
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string? ReturnUrl { get; set; }
    }
}
