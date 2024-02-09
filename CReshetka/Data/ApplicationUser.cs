using Microsoft.AspNetCore.Identity;

namespace CReshetka.Data
{
    public class ApplicationUser : IdentityUser
    {
        public string? NickName { get; set; }
        public string? ProfilePhoto { get; set; }
        public int? Studied { get; set; } //количество просмотренных задач
    }
}
