﻿namespace blogSite.WebUI.Areas.Admin.Models
{
    public class LoginViewModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string? ReturnUrl { get; set; }
    }
}
