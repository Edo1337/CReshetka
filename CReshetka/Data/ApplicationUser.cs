using Microsoft.AspNetCore.Identity;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CReshetka.Data
{
    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser() 
        {
            Studied = 0;
        }
        public string? NickName { get; set; }
        public string? ProfilePhoto { get; set; }

        public int Studied { get; set; } //количество просмотренных задач
    }
}
