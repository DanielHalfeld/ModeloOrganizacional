using Microsoft.AspNetCore.Identity;

namespace ModeloOrganizacional.Models
{
    public class ApplicationUser : IdentityUser
    {
        public virtual ICollection<Topicos> Topicos { get; set; }
    }
}
